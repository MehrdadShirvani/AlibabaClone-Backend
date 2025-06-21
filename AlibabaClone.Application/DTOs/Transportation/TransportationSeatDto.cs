namespace AlibabaClone.Application.DTOs.Transportation
{
    public class TransportationSeatDto
    {
        public long Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsVIP { get; set; }
        public bool IsAvailable { get; set; }
        public string? Description { get; set; }
        public bool IsReserved { get; set; }
        public short? GenderId { get; set; }

    }
}
