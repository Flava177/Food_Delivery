using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record OrderForCreationDto(Guid RestaurantId, string UserId, int OrderStatusId, Guid DispatchDriverId, DateTime OrderDate, DateTime RequestedDeliveryTime, decimal TotalAmount, int RestaurantRating);
}
