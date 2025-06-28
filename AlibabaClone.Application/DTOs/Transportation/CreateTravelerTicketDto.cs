using System.ComponentModel.DataAnnotations;

namespace AlibabaClone.Application.DTOs.Transportation
{
    public class CreateTravelerTicketDto
    {
        public long Id { get; set; }
        public long CreatorAccountId { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "National ID number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "National ID number must be exactly 10 digits.")]
        public string IdNumber { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
        public short GenderId { get; set; }
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Birth date is required.")]
        public DateTime BirthDate { get; set; }
        public string? EnglishFirstName { get; set; }
        public string? EnglishLastName { get; set; }

        public long? SeatId { get; set; }
        public bool IsVIP { get; set; }
        public string Description { get; set; }
    }
}
