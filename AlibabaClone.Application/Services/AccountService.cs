using AlibabaClone.Application.DTOs.Account;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
using AlibabaClone.Domain.Framework.Interfaces;
using AutoMapper;
using System.Runtime.CompilerServices;

namespace AlibabaClone.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IAccountRepository accountRepository, IMapper mapper, IUnitOfWork unitOfWork) 
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
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

    }
}
