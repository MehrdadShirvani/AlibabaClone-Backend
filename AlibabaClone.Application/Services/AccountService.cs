using AlibabaClone.Application.DTOs.Account;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories;
using AlibabaClone.Domain.Framework.Interfaces;
using AutoMapper;
using System.Runtime.CompilerServices;
using AlibabaClone.Application.DTOs.Transportation;
using System.Collections.Generic;

namespace AlibabaClone.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITicketOrderRepository _ticketOrderRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IAccountRepository accountRepository, IMapper mapper, IUnitOfWork unitOfWork, ITicketOrderRepository ticketOrderRepository)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _ticketOrderRepository = ticketOrderRepository;
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
    }
}
