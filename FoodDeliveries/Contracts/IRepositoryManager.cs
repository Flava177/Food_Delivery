using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IRestaurantRepository Restaurant { get; }
        IMenuRepository Menu { get; }
        IOrderRepository Order { get; }
        IUserRepository User { get; }
        IAddressRepository Address { get; }
        IDispatchDriverRepository DispatchDriver  { get; }

        void Save();
    }
}