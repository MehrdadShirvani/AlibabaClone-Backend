using AlibabaClone.Application.DTOs.Account;
using AlibabaClone.Application.DTOs.Authentication;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using AlibabaClone.Application.Utils;
using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Framework.Interfaces;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
using AutoMapper;

namespace AlibabaClone.Application.Services
{
    public class AuthService : IAuthService
    {

        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IAccountRepository accountRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<Result<AuthResponseDto>> RegisterAsync(RegisterRequestDto request)
        {
            var existing = await _accountRepository.GetByPhoneNumberAsync(request.PhoneNumber);
            if (existing != null)
            {
                return Result<AuthResponseDto>.Error(null, "Phone number is already registered");
            }

            if (!IsPasswordStrong(request.Password))
            {
                return Result<AuthResponseDto>.Error(null, "Password must be at least 8 characters and include both digits and letters.");
            }

            var accountDto = new AccountDto
            {
                PhoneNumber = request.PhoneNumber,
                Password = PasswordHasher.HashPassword(request.Password),
                Roles = new List<string> { "User" }
            };

            await _accountRepository.AddAsync(_mapper.Map<Account>(accountDto));
            await _unitOfWork.SaveChangesAsync();
            var account = await _accountRepository.GetByPhoneNumberAsync(accountDto.PhoneNumber);

            var accountRole = new AccountRole
            {
                AccountId = account.Id,   
                RoleId = 1 //TODO: make this better
            };

            await _accountRepository.AddAccountRoleAsync(accountRole);
            await _unitOfWork.SaveChangesAsync();
            
            var response = new AuthResponseDto
            {
                Id = account.Id,
                PhoneNumber = accountDto.PhoneNumber,
                Roles = new List<string> { "User"}, //TODO: make this better
            };

            return Result<AuthResponseDto>.Success(response);
        }

        public async Task<Result<AuthResponseDto>> LoginAsync(LoginRequestDto request)
        {
            var accountDto = _mapper.Map<AccountDto>(await _accountRepository.GetByPhoneNumberAsync(request.PhoneNumber));
            if (accountDto == null)
            {
                return Result<AuthResponseDto>.Error(null, "Invalid phone number or password.");
            }

            if (!PasswordHasher.VerifyPassword(request.Password, accountDto.Password))
            {
                return Result<AuthResponseDto>.Error(null, "Invalid phone number or password.");
            }


            var response = new AuthResponseDto
            {
                Id = accountDto.Id,
                PhoneNumber = accountDto.PhoneNumber,
                Roles = accountDto.Roles,
            };

            return Result<AuthResponseDto>.Success(response);
        }

        private bool IsPasswordStrong(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                return false;

            bool hasDigit = password.Any(char.IsDigit);
            bool hasLetter = password.Any(char.IsLetter);
            return hasDigit && hasLetter;
        }

    }
}
