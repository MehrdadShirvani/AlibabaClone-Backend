namespace AlibabaClone.Application.DTOs.Transaction
{
        public class TransactionDto
        {
            public long Id { get; set; }
            public long? TicketOrderId { get; set; }
            public long? CouponId { get; set; } 
            public DateTime CreatedAt { get; set; }
            public short TransactionTypeId { get; set; }
            public required string TransactionType { get; set; }
            public string? Description { get; set; }
            public decimal BaseAmount { get; set; }
            public decimal FinalAmount { get; set; }
            public required string SerialNumber { get; set; }
        }
}
