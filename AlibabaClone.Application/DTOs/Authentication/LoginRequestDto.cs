namespace AlibabaClone.Application.DTOs.Authentication
{
    public class LoginRequestDto
    {
        public string PhoneNumber { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
