using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record RestaurantForCreationDto(string Name, string Email, string PhoneNumber, TimeSpan StartTime, TimeSpan EndTime, Guid AddressId);

    //public class RestaurantForCreationDto
    //{
    //    public string Name { get; set; }
    //    public string Email { get; set; }
    //    public string PhoneNumber { get; set; }
    //    public TimeSpan StartTime { get; set; }
    //    public TimeSpan EndTime { get; set; }
    //    public Guid AddressId { get; set; }
    //}
}
