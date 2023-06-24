using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    internal sealed class RestaurantRepository : RepositoryBase<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public IEnumerable<Restaurant> GetAllRestaurants(bool trackChanges) =>
            FindAll(trackChanges)
               .OrderBy(c => c.Name)
               .ToList();

        public Restaurant GetRestaurant(Guid restaurantId, bool trackChanges)
        {
            var restaurant = FindByCondition(c => c.Id.Equals(restaurantId), trackChanges)
                .SingleOrDefault();

            return restaurant == null ? throw new Exception("restaurant not found.") : restaurant;
        }
    }
}
