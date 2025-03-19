using AlibabaClone.Domain.Framework.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Domain.Framework.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository AccountRepository { get; }
        ICityRepository CityRepository { get; } 
        ICompanyRepository CompanyRepository { get; }
        IGenderRepository GenderRepository { get; }
        ILocationRepository LocationRepository { get; }
        ILocationTypeRepository LocationTypeRepository { get; }
        IPersonRepository PersonRepository { get; }
        IRoleRepository RoleRepository { get; }
        ISeatRepository SeatRepository { get; }
        ITicketRepository TicketRepository { get; }
        ITicketStatusRepository TicketStatusRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        ITransportationRepository  TransportationRepository { get; }
        IVehicleRepository VehicleRepository { get; }
        IVehicleTypeRepository VehicleTypeRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
