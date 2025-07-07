namespace AlibabaClone.Application.DTOs.Transaction
{
    public class CouponValidationRequestDto
    {
        public required string Code { get; set; }
        public decimal OriginalPrice { get; set; }
    }
}
