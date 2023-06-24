using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class OrderService : IOrderService
    { 
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public OrderService(IRepositoryManager repository, ILoggerManager logger) 
        { 
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<OrderDto> GetAllOrders(bool trackChanges)
        {

            var orders = _repository.Order.GetAllOrders(trackChanges);

            var ordersDto = orders.Select(c =>
            {
                int? restaurantRating = c.RestaurantRating; 
                int rating = restaurantRating.HasValue ? (int)restaurantRating : 0;
                return new OrderDto(c.Id, c.OrderDate, c.RequestedDeliveryTime, c.TotalAmount, rating);
            }).ToList();

            return ordersDto;

        }

        public OrderDto GetOrder(Guid id, bool trackChanges)
        {
            var order = _repository.Order.GetOrder(id, trackChanges);

            var orderDto = new OrderDto(
                id,
                order.OrderDate,
                order.RequestedDeliveryTime,
                order.TotalAmount,
                order.RestaurantRating.HasValue ? (int)order.RestaurantRating : 0
                );

            return orderDto;
        }
    }
}
