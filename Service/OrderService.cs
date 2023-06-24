using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public OrderDto CreateOrderForMenu(Guid restaurantId, string userId, int orderStatusId, Guid dispatchDriverId, OrderForCreationDto orderForCreationDto, bool trackChanges)
        {
            var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges)
            ?? throw new RestaurantNotFoundException(restaurantId);

           var orderEntity = new Order
           {
               RestaurantId = restaurantId,
               UserId = userId,
               OrderStatusId = orderStatusId,
               DispatchDriverId = dispatchDriverId,
               OrderDate = orderForCreationDto.OrderDate,
               RequestedDeliveryTime = orderForCreationDto.RequestedDeliveryTime,
               TotalAmount = orderForCreationDto.TotalAmount,
               RestaurantRating = orderForCreationDto.RestaurantRating
               
           };

            _repository.Order.CreateOrderForMenu(restaurantId, userId, orderStatusId, dispatchDriverId, orderEntity);
            _repository.Save();

            var orderToReturn = new OrderDto(
              orderEntity.Id,
              orderEntity.OrderDate,
              orderEntity.RequestedDeliveryTime,
              orderEntity.TotalAmount,
              (int)orderEntity.RestaurantRating
          );

            return orderToReturn;
        }
    }
}
