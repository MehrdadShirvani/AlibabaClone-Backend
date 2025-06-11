using AlibabaClone.Application.DTOs.Account;
using AlibabaClone.Application.DTOs.City;
using AlibabaClone.Application.DTOs.Transportation;
using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Aggregates.LocationAggregates;
using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AutoMapper;

namespace AlibabaClone.Application.Mappers.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Transportation, TransportationSearchResultDto>()
                .ForMember(dest => dest.CompanyTitle, opt => opt.MapFrom(src => src.Company.Title))
                .ForMember(dest => dest.FromLocationTitle, opt => opt.MapFrom(src => src.FromLocation.Title))
                .ForMember(dest => dest.ToLocationTitle, opt => opt.MapFrom(src => src.ToLocation.Title))
                .ForMember(dest => dest.FromCityTitle, opt => opt.MapFrom(src => src.FromLocation.City.Title))
                .ForMember(dest => dest.ToCityTitle, opt => opt.MapFrom(src => src.ToLocation.City.Title))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.BasePrice));

            CreateMap<City, CityDto>();
            CreateMap<Account, AccountDto>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.AccountRoles.Select(x=>x.Role.Title)));
            CreateMap<AccountDto, Account>() 
            .ForMember(dest => dest.AccountRoles, opt => opt.Ignore());
            
            CreateMap<Account, ProfileDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Person != null ? src.Person.FirstName : ""))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Person != null ? src.Person.LastName : ""))
                .ForMember(dest => dest.AccountPhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PersonPhoneNumber, opt => opt.MapFrom(src => src.Person != null ? src.Person.PhoneNumber : ""))
                .ForMember(dest => dest.IdNumber, opt => opt.MapFrom(src => src.Person != null ? src.Person.IdNumber : ""))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.Person != null ? src.Person.Birthdate : (DateTime?)null))
                .ForMember(dest => dest.BankAccountNumber, opt => opt.MapFrom(src => src.BankAccountDetail != null ? src.BankAccountDetail.BankAccountNumber : ""))
                .ForMember(dest => dest.CardNumber, opt => opt.MapFrom(src => src.BankAccountDetail != null ? src.BankAccountDetail.CardNumber : ""))
                .ForMember(dest => dest.IBAN, opt => opt.MapFrom(src => src.BankAccountDetail != null ? src.BankAccountDetail.IBAN : ""))
                .ForMember(dest => dest.CurrentBalance, opt => opt.MapFrom(src => src.CurrentBalance));

            CreateMap<TicketOrder, TicketOrderSummaryDto>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.SerialNumber))
                    .ForMember(dest => dest.BoughtAt, opt => opt.MapFrom(src => src.CreatedAt))
                    .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Transaction != null ? src.Transaction.FinalAmount : 0))
                    .ForMember(dest => dest.TravelStartDate, opt => opt.MapFrom(src => src.Transportation.StartDateTime))
                    .ForMember(dest => dest.TravelEndDate, opt => opt.MapFrom(src => src.Transportation.EndDateTime))
                    .ForMember(dest => dest.FromCity, opt => opt.MapFrom(src => src.Transportation.FromLocation.City.Title))
                    .ForMember(dest => dest.ToCity, opt => opt.MapFrom(src => src.Transportation.ToLocation.City.Title))
                    .ForMember(dest => dest.VehicleTypeId, opt => opt.MapFrom(src => src.Transportation.VehicleId))
                    .ForMember(dest => dest.VehicleName, opt => opt.MapFrom(src => src.Transportation.Vehicle.Title))
                    .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Transportation.Company.Title))
                    .ForMember(dest => dest.CompanyLogo, opt => opt.MapFrom(src => src.Transportation.Company.Title));
        }
    }
}
