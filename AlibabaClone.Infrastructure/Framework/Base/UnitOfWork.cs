using AlibabaClone.Domain.Framework.Interfaces;
using AlibabaClone.Domain.Framework.Interfaces.Repositories;
using AlibabaClone.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Infrastructure.Framework.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public IAccountRepository AccountRepository { get; }
        public ICityRepository CityRepository {get;}
        public ICompanyRepository CompanyRepository {get;}
        public IGenderRepository GenderRepository {get;}
        public ILocationRepository LocationRepository {get;}
        public ILocationTypeRepository LocationTypeRepository {get;}
        public IPersonRepository PersonRepository {get;}
        public IRoleRepository RoleRepository {get;}
        public ISeatRepository SeatRepository {get;}
        public ITicketRepository TicketRepository {get;}
        public ITicketStatusRepository TicketStatusRepository {get;}
        public ITransactionRepository TransactionRepository {get;}
        public ITransportationRepository TransportationRepository {get;}
        public IVehicleRepository VehicleRepository {get;}
        public IVehicleTypeRepository VehicleTypeRepository {get;}

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            AccountRepository = new AccountRepository(_context);
            PersonRepository = new PersonRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
