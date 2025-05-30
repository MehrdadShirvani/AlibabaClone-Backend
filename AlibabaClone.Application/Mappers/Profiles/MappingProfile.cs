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
            CreateMap<Account, AccountDTO>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.AccountRoles.Select(x=>x.Role.Title)))
                .ReverseMap();
        }
    }
}
