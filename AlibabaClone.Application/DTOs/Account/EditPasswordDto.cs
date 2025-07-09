using System.ComponentModel.DataAnnotations;

namespace AlibabaClone.Application.DTOs.Account
{
    public class EditPasswordDto
    {
        [Required(ErrorMessage = "Old Password is required.")]
        public required string OldPassword {  get; set; }

        [Required(ErrorMessage = "New Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public required string NewPassword { get; set; }
        [Compare(nameof(NewPassword), ErrorMessage = "New Passwords do not match.")]
        public required string ConfirmNewPassword { get; set; }
    }
}
