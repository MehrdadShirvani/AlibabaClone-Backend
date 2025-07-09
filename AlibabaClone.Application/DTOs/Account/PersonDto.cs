using System.ComponentModel.DataAnnotations;

namespace AlibabaClone.Application.DTOs.Account
{
    public class PersonDto
    {
        public long Id { get; set; }
        public long CreatorAccountId { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public required string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public required string LastName { get; set; }
        [Required(ErrorMessage = "National ID number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "National ID number must be exactly 10 digits.")]
        public required string IdNumber { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
        public short GenderId{ get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Phone number format is not valid.")]
        public required string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Birth date is required.")]
        public DateTime BirthDate { get; set; }
        public string? EnglishFirstName { get; set; }
        public string? EnglishLastName { get; set; }
        
    }
}
