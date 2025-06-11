using System.ComponentModel.DataAnnotations;

namespace AlibabaClone.Application.DTOs.Account
{
    public class EditPasswordDto
    {
        [Required(ErrorMessage = "Old Password is required.")]
        public string OldPassword {  get; set; }

        [Required(ErrorMessage = "New Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string NewPassword { get; set; }
        [Compare(nameof(NewPassword), ErrorMessage = "New Passwords do not match.")]
        public string ConfirmNewPassword { get; set; }
    }
}
