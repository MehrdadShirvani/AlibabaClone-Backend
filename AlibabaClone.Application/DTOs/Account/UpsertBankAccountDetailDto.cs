namespace AlibabaClone.Application.DTOs.Account
{
    public class UpsertBankAccountDetailDto
    {
        public string? IBAN { get; set; }              // 24 digits
        public string? CardNumber { get; set; }        // 16 digits, optional format xxxx-xxxx-xxxx-xxxx
        public string? BankAccountNumber { get; set; }
    }
}
