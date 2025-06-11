using AlibabaClone.Application.DTOs.Account;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories;
using AlibabaClone.Domain.Framework.Interfaces;
using AutoMapper;
using AlibabaClone.Application.DTOs.Transportation;
using AlibabaClone.Application.DTOs.Transaction;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionRepositories;

namespace AlibabaClone.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITicketOrderRepository _ticketOrderRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IMapper mapper,
                              IUnitOfWork unitOfWork,
                              IAccountRepository accountRepository,
                              ITicketOrderRepository ticketOrderRepository, 
                              ITicketRepository ticketRepository, 
                              ITransactionRepository transactionRepository)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _ticketOrderRepository = ticketOrderRepository;
            _ticketRepository = ticketRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<Result<ProfileDto>> GetProfileAsync(long accountId)
        {
            var result  = await _accountRepository.GetProfileAsync(accountId);
            if (result != null)
            {
                return Result<ProfileDto>.Success(_mapper.Map<ProfileDto>(result));
            }
         
            return Result<ProfileDto>.NotFound(null);
        }

        public async Task<Result<List<TicketOrderSummaryDto>>> GetTravels(long accountId)
        {
            var result = await _ticketOrderRepository.GetAllByBuyerId(accountId);
            if (result != null)
            {
                return Result<List<TicketOrderSummaryDto>>.Success(_mapper.Map<List<TicketOrderSummaryDto>>(result));
            }

            return Result<List<TicketOrderSummaryDto>>.NotFound(null);
        }

        public async Task<Result<List<TravelerTicketDto>>> GetTicketOrderTravelersDetails(long accountId, long ticketOrderId)
        {
            var result = await _ticketRepository.GetAllTicketsByTicketOrderId(ticketOrderId);
            if (result != null)
            {
                if(result.Count > 0 && result.First().TicketOrder.BuyerId != accountId)
                {
                    return Result<List<TravelerTicketDto>>.Unauthorized(null);
                }

                return Result<List<TravelerTicketDto>>.Success(_mapper.Map<List<TravelerTicketDto>>(result));
            }

            return Result<List<TravelerTicketDto>>.NotFound(null);
        }

        public async Task<Result<List<TransactionDto>>> GetTransactions(long accountId)
        {
            var result = await _transactionRepository.GetAllByAccountIdAsync(accountId);
            if (result != null)
            {
                return Result<List<TransactionDto>>.Success(_mapper.Map<List<TransactionDto>>(result));
            }

            return Result<List<TransactionDto>>.NotFound(null);
        }
    }
}
