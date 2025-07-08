using AlibabaClone.Application.DTOs.Account;
using AlibabaClone.Application.DTOs.Transaction;
using AlibabaClone.Application.DTOs.Transportation;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Enums;
using AlibabaClone.Domain.Framework.Interfaces;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionRepositories;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.VehicleRepositories;
using AutoMapper;

namespace AlibabaClone.Application.Services
{
    public class TicketOrderService : ITicketOrderService
    {
        private readonly ITicketOrderRepository _ticketOrderRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IPersonRepository _personRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly ITransportationRepository _transportationRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly ICouponRepository _couponRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonService _personService;
        private readonly ITransactionService _transactionService;
        private readonly IAccountService _accountService;
        private readonly ICouponService _couponService;
        private readonly IPdfGenerator _pdfGeneratorService;
        private readonly IMapper _mapper;
        private readonly ITransportationLockService _transportationLockService;
        public TicketOrderService(ITicketOrderRepository ticketOrderRepository,
                                  ITicketRepository ticketRepository,
                                  IUnitOfWork unitOfWork,
                                  ITransportationRepository transportationRepository,
                                  IAccountRepository accountRepository,
                                  ISeatRepository seatRepository,
                                  IPersonRepository personRepository,
                                  IPersonService personService,
                                  ITransactionService transactionService,
                                  IMapper mapper,
                                  IAccountService accountService,
                                  IPdfGenerator pdfGeneratorService,
                                  ICouponService couponService,
                                  ICouponRepository couponRepository,
                                  ITransportationLockService transportationLockService)
        {
            _ticketOrderRepository = ticketOrderRepository;
            _ticketRepository = ticketRepository;
            _transportationRepository = transportationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _accountRepository = accountRepository;
            _seatRepository = seatRepository;
            _personRepository = personRepository;
            _personService = personService;
            _transactionService = transactionService;
            _accountService = accountService;
            _pdfGeneratorService = pdfGeneratorService;
            _couponService = couponService;
            _couponRepository = couponRepository;
            _transportationLockService = transportationLockService;
        }
        public async Task<Result<long>> CreateTicketOrderAsync(long accountId, CreateTicketOrderDto dto)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account == null) return Result<long>.Error("Account not found");

            var transportation = await _transportationRepository.GetByIdAsync(dto.TransportationId);
            if (transportation == null) return Result<long>.Error("Transportation not found");

            using (await _transportationLockService.AcquireLockAsync(dto.TransportationId))
            {
                var baseAmount = transportation.BasePrice * dto.Travelers.Count;
                if (account.CurrentBalance < baseAmount) return Result<long>.Error("Not enough money");
                var seatCheck = ValidateTransportationAndSeats(transportation, dto.Travelers);
                if (!string.IsNullOrEmpty(seatCheck)) return Result<long>.Error(seatCheck);
                var finalAmount = baseAmount;
                long? couponId = null;
                if (!string.IsNullOrEmpty(dto.CouponCode))
                {
                    var couponCheck = await _couponService.ValidateCouponAsync(accountId, new CouponValidationRequestDto { Code = dto.CouponCode, OriginalPrice = baseAmount });
                    var coupon = await _couponRepository.GetByCodeAsync(dto.CouponCode);
                    if (couponCheck.IsSuccess == false || (couponCheck.Data?.IsValid ?? false) == false || coupon == null)
                    {
                        return Result<long>.Error("Coupon code is not valid");
                    }
                    couponId = coupon.Id;
                    finalAmount = baseAmount - couponCheck.Data.DiscountAmount;
                }

                await AssignSeatsIfDynamic(transportation.VehicleId, dto.Travelers);
                await UpsertTravelers(account.Id, dto.Travelers);

                var ticketOrder = new TicketOrder
                {
                    BuyerId = account.Id,
                    CreatedAt = DateTime.UtcNow,
                    Description = "",
                    SerialNumber = Guid.NewGuid().ToString("N"),
                    TransportationId = dto.TransportationId,
                };
                await _ticketOrderRepository.AddAsync(ticketOrder);

                foreach (var traveler in dto.Travelers)
                {
                    if (traveler.SeatId.HasValue == false)
                    {
                        return Result<long>.Error("Something went wrong");
                    }
                    var ticket = new Ticket
                    {
                        CreatedAt = DateTime.UtcNow,
                        Description = traveler.Description,
                        SeatId = traveler.SeatId.Value,
                        SerialNumber = Guid.NewGuid().ToString("N"),
                        TicketOrder = ticketOrder,
                        TicketStatusId = 1,
                        TravelerId = traveler.Id,
                    };
                    await _ticketRepository.AddAsync(ticket);
                }

                await _unitOfWork.SaveChangesAsync();
                await _accountService.PayForTicketOrderAsync(account.Id, ticketOrder.Id, baseAmount, finalAmount, couponId);
                return Result<long>.Success(ticketOrder.Id);
            }
        }



        private async Task UpsertTravelers(long id, List<CreateTravelerTicketDto> travelers)
        {
            foreach (var traveler in travelers)
            {
                var person = (await _personRepository.FindAsync(x => x.IdNumber == traveler.IdNumber && x.CreatorAccountId == id)).FirstOrDefault();
                if (person != null)
                {
                    traveler.Id = person.Id;
                }

                traveler.CreatorAccountId = id;
                var result = await _personService.UpsertPersonAsync(id, _mapper.Map<PersonDto>(traveler));
                traveler.Id = result.Data;
            }
        }

        private async Task AssignSeatsIfDynamic(int vehicleId, List<CreateTravelerTicketDto> travelers)
        {
            var allSeats = await _seatRepository.GetSeatsByVehicleId(vehicleId);
            var reservedSeats = allSeats.Where(x => x.Tickets.Any(y => y.TicketStatusId == (int)TicketStatusEnum.Reserved));

            if (vehicleId == (int)VehicleTypeEnum.Bus)
            {
                var seatIdsToReserve = travelers.Select(x => x.SeatId ?? 0).ToList();
                if (seatIdsToReserve.Intersect(reservedSeats.Select(x => x.Id)).Any() || seatIdsToReserve.Any(x => x == 0))
                {
                    throw new Exception();
                }
            }
            else
            {
                var freeSeats = allSeats.Where(x => x.Tickets.All(y => y.TicketStatusId != (int)TicketStatusEnum.Reserved)).ToList();
                int i = 0;
                travelers.ForEach(x =>
                {
                    x.SeatId = freeSeats[i].Id;
                    i++;
                });
            }
        }

        private string ValidateTransportationAndSeats(Transportation? transportation, List<CreateTravelerTicketDto> travelers)
        {
            if (transportation == null) return "Transportation not found";
            if (transportation.StartDateTime <= DateTime.Now) return "Too late to reserve";
            if (transportation.RemainingCapacity < travelers.Count) return "No place";
            return "";
        }

        public async Task<Result<byte[]>> GenerateTicketsPdfAsync(long accountId, long ticketOrderId)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account == null) return Result<byte[]>.Error("Account not found");

            var ticketOrder = await _ticketOrderRepository.FindAndLoadAllDetails(ticketOrderId);
            if (ticketOrder == null) return Result<byte[]>.Error("Transportation not found");
            if (ticketOrder.BuyerId != accountId) return Result<byte[]>.Error("Wrong Transportation");
            var data = _pdfGeneratorService.GenerateTicketsPdf(ticketOrder);
            return Result<byte[]>.Success(data);
        }
    }
}
