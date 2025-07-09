namespace AlibabaClone.Application.DTOs.Transportation
{
    public class TravelerTicketDto
    {
        public long Id { get; set; }
        public required string SerialNumber { get; set; }
        public required string TravelerName { get; set; }
        public DateTime BirthDate { get; set; }
        public required string SeatNumber { get; set; }
        public required string TicketStatus { get; set; }
        public string? CompanionName { get; set; }
        public string? Description { get; set; }

    }
}
