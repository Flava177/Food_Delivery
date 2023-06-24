using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class OrderStatus
    {
        [Column("OrderStatusId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Status value is a required field.")]
        [MaxLength(55, ErrorMessage = "Maximum length for Status value is 55 characters.")]
        public string StatusValue { get; set; }
    }
}
