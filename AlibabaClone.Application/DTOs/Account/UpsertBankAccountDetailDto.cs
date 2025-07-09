namespace AlibabaClone.Application.DTOs.Account
{
    public class UpsertBankAccountDetailDto
    {
        public string? IBAN { get; set; }              
        public string? CardNumber { get; set; }        
        public string? BankAccountNumber { get; set; }
    }
}
