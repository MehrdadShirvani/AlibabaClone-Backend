namespace AlibabaClone.Application.DTOs.Transportation
{
    public class TicketOrderSummaryDto
    {
        public long Id { get; set; }
        public string SerialNumber { get; set; }
        public DateTime BoughtAt{ get; set; }
        //Transaction data
        public decimal TotalPrice { get; set; }
        //Transportation
        public DateTime TravelStartDate { get; set; }
        public DateTime? TravelEndDate { get; set; }
        //City Data
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        //Company Data
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        //Vehicle Data
        public int VehicleTypeId { get; set; }
        public string VehicleName{ get; set; }
        
        

    }
}
