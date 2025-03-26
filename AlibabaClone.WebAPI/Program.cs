using AlibabaClone.Domain.Framework.Interfaces;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.CompanyAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.LocationAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.VehicleAggregates;
using AlibabaClone.Infrastructure;
using AlibabaClone.Infrastructure.Framework.Base;
using AlibabaClone.Infrastructure.Services.AccountAggregates;
using AlibabaClone.Infrastructure.Services.CompanyAggregates;
using AlibabaClone.Infrastructure.Services.TransactionAggregates;
using AlibabaClone.Infrastructure.Services.TransportationAggregates;
using AlibabaClone.Infrastructure.Services.VehicleAggregates;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(connectionString));

//Register Repositories
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IGenderRepository, GenderRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationTypeRepository, LocationTypeRepository>();

builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketStatusRepository, TicketStatusRepository>();
builder.Services.AddScoped<ITransportationRepository, TransportationRepository>();

builder.Services.AddScoped<ISeatRepository, SeatRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();

//Register Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
