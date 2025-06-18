namespace AlibabaClone.Application.DTOs.Transaction
{
    public class TransactionDto
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public short TransactionTypeId { get; set; }
        public string TransactionType { get; set; }
        public string Description { get; set; }
        public decimal FinalAmount { get; set; }
    }
}
