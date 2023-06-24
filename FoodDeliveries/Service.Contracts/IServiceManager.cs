using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        IRestaurantService RestaurantService { get; }
        IMenuService MenuService { get; }
        IOrderService OrderService { get; }
        IUserService UserService { get; }
        IAddressService AddressService { get; }
        IDispatchDriverService DispatchDriverService { get; }

    }
}
