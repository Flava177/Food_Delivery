using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders(bool trackChanges);
        Order GetOrder(Guid orderId, bool trackChanges);
        void CreateOrderForMenu(Guid restaurantId, string userId, int orderStatusId, Guid dispatchDriverId, Order order);
    }
}
