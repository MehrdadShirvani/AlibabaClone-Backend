namespace AlibabaClone.Application.DTOs.Account
{
    public class ProfileDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public required string AccountPhoneNumber { get; set; }
        public string? Email { get; set; }
        
        public string? IdNumber{ get; set; }
        public string? PersonPhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }

        public string? IBAN { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? CardNumber { get; set; }

        public decimal CurrentBalance { get; set; }
    }
}
