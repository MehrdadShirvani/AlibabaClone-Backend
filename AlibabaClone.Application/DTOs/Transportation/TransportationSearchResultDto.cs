﻿namespace AlibabaClone.Application.DTOs.Transportation
{
    public class TransportationSearchResultDto
    {
        public long Id { get; init; }
        public required string CompanyTitle { get; init; }   
        public required string FromLocationTitle { get; init; }
        public required string ToLocationTitle { get; init; }
        public required string FromCityTitle { get; init; }
        public required string ToCityTitle { get; init; }
        public DateTime StartDateTime { get; init; }
        public DateTime? EndDateTime { get; init; }
        public decimal Price { get; init; } 
    }
}
