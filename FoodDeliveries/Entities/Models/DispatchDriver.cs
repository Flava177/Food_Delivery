using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class DispatchDriver
    {
        [Column("DispatchDriverId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Full Name is a required field.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }
    }
}