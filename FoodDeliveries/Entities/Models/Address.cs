using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Address
    {
        [Column("AddressId")]
        public Guid Id { get; set; }

        [MaxLength(55, ErrorMessage = "Maximum length for Street is 55 characters.")]
        public string? Street { get; set; }

        [Required(ErrorMessage = "Area is a required field.")]
        [MaxLength(55, ErrorMessage = "Maximum length for the Area is 55 characters.")]

        public string Area { get; set; }

        [Required(ErrorMessage = "City is a required field.")]
        [MaxLength(55, ErrorMessage = "Maximum length for the City is 55 characters.")]
        public string City { get; set; }
    }
}
