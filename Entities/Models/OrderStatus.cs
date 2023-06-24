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
        public int Id { get; set; }

        [MaxLength(30, ErrorMessage = "Maximum length for Status value is 30 characters.")]
        public string StatusValue { get; set; }
    }
}
