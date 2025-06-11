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
using AlibabaClone.Application.Utils;
using AlibabaClone.Domain.Aggregates.AccountAggregates;
using System.ComponentModel.DataAnnotations;

namespace AlibabaClone.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IBankAccountDetailRepository _bankAccountDetailRepository;
        private readonly ITicketOrderRepository _ticketOrderRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IMapper mapper,
                              IUnitOfWork unitOfWork,
                              IAccountRepository accountRepository,
                              IPersonRepository personRepository,
                              ITicketOrderRepository ticketOrderRepository,
                              ITicketRepository ticketRepository,
                              ITransactionRepository transactionRepository,
                              IBankAccountDetailRepository bankAccountDetailRepository)
        {
            _accountRepository = accountRepository;
            _personRepository = personRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _ticketOrderRepository = ticketOrderRepository;
            _ticketRepository = ticketRepository;
            _transactionRepository = transactionRepository;
            _bankAccountDetailRepository = bankAccountDetailRepository;
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

        public async Task<Result<long>> UpdateEmailAsync(long accountId, string newEmail)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account == null) throw new Exception("Account not found");
            var accountByNewEmail = await _accountRepository.GetByEmailAsync(newEmail);
            if (accountByNewEmail != null )
            {
                if(accountByNewEmail.Id != accountId)
                {
                    return Result<long>.Error(account.Id, "Email is used by another account");
                }
                else
                {
                    return Result<long>.Success(account.Id);
                }
            }


            account.Email = newEmail;
            _accountRepository.Update(account);
            await _unitOfWork.SaveChangesAsync();
            return Result<long>.Success(account.Id);
        }

        public async Task<Result<long>> UpdatePasswordAsync(long accountId, string oldPassword, string newPassword)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account == null) throw new Exception("Account not found");
            if (!PasswordHasher.VerifyPassword(oldPassword, account.Password))
            {
                return Result<long>.Error(0, "Invalid password.");
            }

            if (!IsPasswordStrong(newPassword))
            {
                return Result<long>.Error(0, "New Password must be at least 8 characters and include both digits and letters.");
            }

            account.Password = PasswordHasher.HashPassword(newPassword);
            _accountRepository.Update(account);
            await _unitOfWork.SaveChangesAsync();
            return Result<long>.Success(account.Id);
        }

        private bool IsPasswordStrong(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                return false;

            bool hasDigit = password.Any(char.IsDigit);
            bool hasLetter = password.Any(char.IsLetter);
            return hasDigit && hasLetter;
        }

        public async Task<Result<long>> UpsertPersonAsync(long accountId, PersonDto dto)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account == null) throw new Exception("Account not found");
            Person person;
            if(account.PersonId.HasValue)
            {
                person = await _personRepository.GetByIdAsync(account.PersonId.Value);
                if (account == null) throw new Exception("Person not found");
                person.FirstName = dto.FirstName;
                person.LastName = dto.LastName;
                person.IdNumber = dto.IdNumber;
                person.Birthdate = dto.BirthDate;
                person.CreatorAccountId = accountId;
                person.EnglishFirstName = dto.EnglishFirstName;
                person.EnglishLastName = dto.EnglishLastName;
                person.GenderId = dto.GenderId;
                person.PhoneNumber = dto.PhoneNumber;
                _personRepository.Update(person);
            }
            else
            {
                person = new Person { 
                    FirstName = dto.FirstName, 
                    LastName = dto.LastName,
                    IdNumber = dto.IdNumber,
                    Birthdate = dto.BirthDate,
                    CreatorAccountId = accountId,
                    EnglishFirstName = dto.EnglishFirstName,
                    EnglishLastName = dto.EnglishLastName,
                    GenderId = dto.GenderId,
                    PhoneNumber = dto.PhoneNumber,
                };
                await _personRepository.AddAsync(person);
            }

            await _unitOfWork.SaveChangesAsync();
            return Result<long>.Success(person.Id);
        }

        public async Task<Result<long>> UpsertBankAccountDetailAsync(long accountId, UpsertBankAccountDetailDto dto)
        {
            var error = ValidateBankInfo(dto);
            if(string.IsNullOrEmpty(error) == false)
            {
                return Result<long>.Error(0, error);
            }

            var detail = await _bankAccountDetailRepository.GetByAccountIdAsync(accountId);
            if (detail == null)
            {
                detail = new BankAccountDetail()
                {
                    AccountId = accountId,
                    BankAccountNumber = dto.BankAccountNumber,
                    CardNumber = dto.CardNumber,
                    IBAN = dto.IBAN,
                };

                await _bankAccountDetailRepository.AddAsync(detail);
            }
            else
            {
                detail.BankAccountNumber = dto.BankAccountNumber;
                detail.CardNumber = dto.CardNumber;
                detail.IBAN = dto.IBAN;

                _bankAccountDetailRepository.Update(detail);
            }

            await _unitOfWork.SaveChangesAsync();
            return Result<long>.Success(detail.Id);
        }

        private string ValidateBankInfo(UpsertBankAccountDetailDto dto)
        {
            if (!string.IsNullOrEmpty(dto.IBAN) && dto.IBAN.Length != 24 && dto.IBAN.Any(x=> char.IsDigit(x) == false))
                return "IBAN must be 24 digits";

            if (!string.IsNullOrEmpty(dto.CardNumber))
            {
                var digitsOnly = dto.CardNumber.Replace("-", "");
                if (digitsOnly.Length != 16 || !digitsOnly.All(char.IsDigit))
                    return "Invalid Card Number format";
            }
            return "";
        }
    }
}
