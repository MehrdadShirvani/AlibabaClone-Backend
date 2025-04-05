﻿using AlibabaClone.Application.DTOs.Transportation;
using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .ForMember(dest => dest.ToCityTitle, opt => opt.MapFrom(src => src.ToLocation.City.Title));
        }
    }
}
