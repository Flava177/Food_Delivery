using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class User : IdentityUser
    {

        [Required(ErrorMessage = "FirstName is a required field.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is a required field.")]
        public string LastName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
