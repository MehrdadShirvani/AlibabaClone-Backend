using System.ComponentModel.DataAnnotations;

namespace AlibabaClone.Application.DTOs.Account
{
    public class EditEmailDto
    {
        [Required, EmailAddress(ErrorMessage = "Email is not valid")]
        public required string NewEmail { get; set; }
    }
}
