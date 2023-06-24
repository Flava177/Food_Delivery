using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal sealed class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<Order> GetAllOrders(bool trackChanges) =>
            FindAll(trackChanges)
               .OrderBy(c => c.OrderDate)
               .ToList();

        public Order GetOrder(Guid orderId, bool trackChanges)
        {
            var order = FindByCondition(c => c.Id.Equals(orderId), trackChanges)
                .SingleOrDefault();

            return order == null ? throw new Exception("order not found.") : order;
        }

    }
}
