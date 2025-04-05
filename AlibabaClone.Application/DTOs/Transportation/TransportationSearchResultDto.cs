namespace AlibabaClone.Application.DTOs.Transportation
{
    public class TransportationSearchResultDto
    {
        public int Id { get; init; }
        public string CompanyTitle { get; init; }   
        public string FromLocationTitle { get; init; }
        public string ToLocationTitle { get; init; }
        public string FromCityTitle { get; init; }
        public string ToCityTitle { get; init; }
        public DateTime StartDateTime { get; init; }
        public DateTime EndDateTime{ get; init; }
        public decimal Price { get; init; } 
    }
}
