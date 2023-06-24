using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class RestaurantNotFoundException : NotFoundException
    {
        public RestaurantNotFoundException(Guid restaurantId) 
            : base($"The restaurant with id: {restaurantId} doesn't exist in the database.")
        { }
    }
}
