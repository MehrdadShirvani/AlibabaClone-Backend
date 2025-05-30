namespace AlibabaClone.Application.DTOs.Authentication
{
    public class AuthResponseDto
    {
        public long Id { get; set; }
        public string Token { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public List<string> Roles { get; set; }
    }
}
