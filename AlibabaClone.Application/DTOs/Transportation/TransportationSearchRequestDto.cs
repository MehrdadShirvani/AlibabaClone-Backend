namespace AlibabaClone.Application.DTOs.Transportation
{
    public class TransportationSearchRequestDto
    {
        public int? FromCityId { get; init; }
        public int? ToCityId { get; init; }
        public DateTime? StartDate { get; init; }
        public DateTime? EndDate { get; init; }
    }
}
