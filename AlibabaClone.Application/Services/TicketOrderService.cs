using AlibabaClone.Application.DTOs.Account;
using AlibabaClone.Application.DTOs.Transaction;
using AlibabaClone.Application.DTOs.Transportation;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using AlibabaClone.Domain.Aggregates.TransportationAggregates;
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
        ITicketOrderRepository _ticketOrderRepository;
        IAccountRepository _accountRepository;
        IPersonRepository _personRepository;
        ITicketRepository _ticketRepository;
        ITransportationRepository _transportationRepository;
        ISeatRepository _seatRepository;
        ICouponRepository _couponRepository;
        IUnitOfWork _unitOfWork;
        IPersonService _personService;
        ITransactionService _transactionService;
        IAccountService _accountService;
        ICouponService _couponService;
        IPdfGenerator _pdfGeneratorService;

        IMapper _mapper;
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
                                  ICouponRepository couponRepository)
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
        }
        public async Task<Result<long>> CreateTicketOrderAsync(long accountId, CreateTicketOrderDto dto)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account == null) return Result<long>.Error("Account not found");

            var transportation = await _transportationRepository.GetByIdAsync(dto.TransportationId);
            if (transportation == null) return Result<long>.Error("Transportation not found");
            var baseAmount = transportation.BasePrice * dto.Travelers.Count;
            if (account.CurrentBalance < baseAmount) return Result<long>.Error("Not enough money");
            var seatCheck = ValidateTransportationAndSeats(transportation, dto.Travelers);
            if (!string.IsNullOrEmpty(seatCheck)) return Result<long>.Error(seatCheck);
            var finalAmount = baseAmount;
            long? couponId = null;
            if(!string.IsNullOrEmpty(dto.CouponCode))
            {
                var couponCheck = await _couponService.ValidateCouponAsync(accountId, new CouponValidationRequestDto { Code = dto.CouponCode, OriginalPrice = baseAmount });
                if(couponCheck.IsSuccess == false || (couponCheck.Data?.IsValid ?? false) == false)
                {
                    return Result<long>.Error("Coupon code not valid");
                }
                finalAmount = baseAmount - couponCheck.Data.DiscountAmount;
                couponId = (await _couponRepository.GetByCodeAsync(dto.CouponCode)).Id;
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
            var reservedSeats = allSeats.Where(x => x.Tickets.Any(y => y.TicketStatusId == 1));

            if (vehicleId == 1) 
            {
                var seatIdsToReserve = travelers.Select(x => x.SeatId.Value).ToList();
                if (seatIdsToReserve.Intersect(reservedSeats.Select(x => x.Id)).Any())
                {
                    throw new Exception();
                }
            }
            else
            {
                var freeSeats = allSeats.Where(x => x.Tickets.All(y => y.TicketStatusId != 1)).ToList();
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
