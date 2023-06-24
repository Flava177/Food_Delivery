using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class RestaurantService : IRestaurantService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public RestaurantService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<RestaurantDto> GetAllRestaurants(bool trackChanges)
        {

            var restaurants = _repository.Restaurant.GetAllRestaurants(trackChanges);

            var restaurantsDto = restaurants.Select(c =>

            new RestaurantDto(c.Id, c.Name, c.Email, c.PhoneNumber, c.StartTime, c.EndTime)).ToList();

            return restaurantsDto;

        }

        public RestaurantDto GetRestaurant(Guid id, bool trackChanges)
        {
            var restaurant = _repository.Restaurant.GetRestaurant(id, trackChanges);

            var restaurantDto = new RestaurantDto(
                id,
                restaurant.Name,
                restaurant.Email,
                restaurant.PhoneNumber,
                restaurant.StartTime,
                restaurant.EndTime
                
                );

            return restaurantDto;
        }
    }
}
