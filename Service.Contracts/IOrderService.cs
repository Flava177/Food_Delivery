using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetAllOrders(bool trackChanges);
        OrderDto GetOrder(Guid orderId, bool trackChanges);
        OrderDto CreateOrderForMenu(OrderForCreationDto orderForCreationDto, bool trackChanges);
    }
}
