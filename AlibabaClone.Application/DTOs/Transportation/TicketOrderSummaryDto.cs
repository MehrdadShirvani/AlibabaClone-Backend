namespace AlibabaClone.Application.DTOs.Transportation
{
    public class TicketOrderSummaryDto
    {
        public long Id { get; set; }
        public required string SerialNumber { get; set; }
        public DateTime BoughtAt{ get; set; }

        public decimal TotalPrice { get; set; }
        
        public DateTime TravelStartDate { get; set; }
        public DateTime? TravelEndDate { get; set; }
        
        public required string FromCity { get; set; }
        public required string ToCity { get; set; }
        
        public required string CompanyName { get; set; }
        public required string CompanyLogo { get; set; }

        public int VehicleTypeId { get; set; }
        public required string VehicleName{ get; set; }
    }
}
