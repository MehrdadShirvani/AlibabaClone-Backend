using AlibabaClone.Application.DTOs.Account;
using AlibabaClone.Application.DTOs.Transaction;
using AlibabaClone.Application.DTOs.Transportation;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Interfaces;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
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
        IUnitOfWork _unitOfWork;
        IPersonService _personService;
        ITransactionService _transactionService;
        IAccountService _accountService;
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
                                  IAccountService accountService)
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
        }
        public async Task<Result<long>> CreateTicketOrderAsync(long accountId, CreateTicketOrderDto dto)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account == null) return Result<long>.Error(0, "Account not found");

            var transportation = await _transportationRepository.GetByIdAsync(dto.TransportationId);
            if (transportation == null) return Result<long>.Error(0, "Transportation not found");
            var price = transportation.BasePrice * dto.Travelers.Count;
            if (account.CurrentBalance < price) return Result<long>.Error(0, "Not enough money");
            var seatCheck = ValidateTransportationAndSeats(transportation, dto.Travelers);
            if (!string.IsNullOrEmpty(seatCheck)) return Result<long>.Error(0, seatCheck);


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
            await _accountService.PayForTicketOrderAsync(account.Id, ticketOrder.Id, price);
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

            if (vehicleId == 1)//vehicleId == 1
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

    }
}
