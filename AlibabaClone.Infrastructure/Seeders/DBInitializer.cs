using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Aggregates.LocationAggregates;
using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Aggregates.VehicleAggregates;
using Microsoft.EntityFrameworkCore;

namespace AlibabaClone.Infrastructure.Seeders
{
    public class DBInitializer
    {
        public static async Task SeedAsync(ApplicationDBContext context)
        {
            if (!await context.Genders.AnyAsync())
            {
                context.Genders.AddRange(
                    new Gender { Id = 1, Title = "Female" },
                    new Gender { Id = 2, Title = "Male" }
                );
            }

            if (!await context.LocationTypes.AnyAsync())
            {
                context.LocationTypes.AddRange(
                    new LocationType { Id = 1, Title = "BusTerminal" },
                    new LocationType { Id = 2, Title = "TrainStation" },
                    new LocationType { Id = 3, Title = "Airport" },
                    new LocationType { Id = 4, Title = "Seaport" },
                    new LocationType { Id = 5, Title = "MetroStation" }
                );
            }

            if (!await context.Roles.AnyAsync())
            {
                context.Roles.AddRange(
                    new Role { Id = 1, Title = "User" },
                    new Role { Id = 2, Title = "Admin" }
                );
            }

            if (!await context.TicketStatuses.AnyAsync())
            {
                context.TicketStatuses.AddRange(
                    new TicketStatus { Id = 1, Title = "Reserved" },
                    new TicketStatus { Id = 2, Title = "Paid" },
                    new TicketStatus { Id = 3, Title = "CancelledByUser" },
                    new TicketStatus { Id = 4, Title = "CancelledBySystem" },
                    new TicketStatus { Id = 5, Title = "Used" },
                    new TicketStatus { Id = 6, Title = "Expired" }
                );
            }

            if (!await context.TransactionTypes.AnyAsync())
            {
                context.TransactionTypes.AddRange(
                    new TransactionType { Id = 1, Title = "Deposit" },
                    new TransactionType { Id = 2, Title = "Withdraw" }
                );
            }

            if (!await context.VehicleTypes.AnyAsync())
            {
                context.VehicleTypes.AddRange(
                    new VehicleType { Id = 1, Title = "Bus" },
                    new VehicleType { Id = 2, Title = "Train" },
                    new VehicleType { Id = 3, Title = "Airplane" },
                    new VehicleType { Id = 4, Title = "Ship" },
                    new VehicleType { Id = 5, Title = "Metro" }
                );
            }

            await context.SaveChangesAsync();
        }
    }
}
