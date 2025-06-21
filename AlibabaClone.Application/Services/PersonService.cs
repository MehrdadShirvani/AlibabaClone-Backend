using AlibabaClone.Application.DTOs.Account;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
using AlibabaClone.Domain.Framework.Interfaces;
using AutoMapper;

namespace AlibabaClone.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PersonService(IMapper mapper,
                              IUnitOfWork unitOfWork,
                              IAccountRepository accountRepository,
                              IPersonRepository personRepository)
        {
            _accountRepository = accountRepository;
            _personRepository = personRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<long>> UpsertAccountPersonAsync(long accountId, PersonDto dto)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account == null) return Result<long>.Error(0, "Account not found");
            Person person;
            if (account.PersonId.HasValue)
            {
                person = await _personRepository.GetByIdAsync(account.PersonId.Value);
                if (person == null) return Result<long>.Error(0, "Person not found");
                _mapper.Map(dto, person);
                person.CreatorAccountId = account.Id;
                person.Id = account.PersonId.Value;
                _personRepository.Update(person);
            }
            else
            {
                person = _mapper.Map<Person>(dto);
                person.CreatorAccountId = account.Id;
                await _personRepository.AddAsync(person);
            }

            await _unitOfWork.SaveChangesAsync();

            account.PersonId = person.Id;
            _accountRepository.Update(account);
            await _unitOfWork.SaveChangesAsync();

            return Result<long>.Success(person.Id);
        }

        public async Task<Result<long>> UpsertPersonAsync(long accountId, PersonDto dto)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account == null) return Result<long>.Error(0, "Account not found");


            Person person;
            person = (await _personRepository.FindAsync(x => x.IdNumber == dto.IdNumber && x.CreatorAccountId == accountId)).FirstOrDefault();
            if (person != null)
            {
                if (dto.Id > 0 && dto.Id != person.Id)
                {
                    return Result<long>.Error(0, "A person with this id number exists");
                }
                _mapper.Map(dto, person);
                person.CreatorAccountId = account.Id;
                _personRepository.Update(person);
            }
            else
            {
                person = _mapper.Map<Person>(dto);
                person.CreatorAccountId = accountId;
                await _personRepository.AddAsync(person);
            }

            await _unitOfWork.SaveChangesAsync();

            return Result<long>.Success(person.Id);
        }
    }
}
