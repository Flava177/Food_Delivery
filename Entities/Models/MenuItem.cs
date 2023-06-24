using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entities.Models
{
    public class MenuItem
    {
        [Column("MenuItemId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "MenuItem name is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Name is 100 characters.")]
        public string Name { get; set; }

        [MaxLength(100, ErrorMessage = "Maximum length for Description is 100 characters.")]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Price { get; set; }

        [ForeignKey(nameof(Restaurant))] 
        public Guid RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }

    }
}
