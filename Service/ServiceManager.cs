using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAddressService> _addressService ;
        private readonly Lazy<IDispatchDriverService> _dispatchDriverService ;
        private readonly Lazy<IMenuService> _menuService ;
        private readonly Lazy<IOrderService> _orderService ;
        private readonly Lazy<IRestaurantService> _restaurantService ;
        private readonly Lazy<IUserService> _userService  ;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, HttpClient httpClient)
        {
            _addressService = new Lazy<IAddressService>(() => new AddressService(repositoryManager, logger));
            _dispatchDriverService = new Lazy<IDispatchDriverService>(() => new DispatchDriverService(repositoryManager, logger));
            _menuService = new Lazy<IMenuService>(() => new MenuService(repositoryManager, logger));
            _orderService = new Lazy<IOrderService>(() => new OrderService(repositoryManager, logger));
            _restaurantService = new Lazy<IRestaurantService>(() => new RestaurantService(repositoryManager, logger));
            _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, logger));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, userManager, roleManager, configuration, httpContextAccessor, httpClient));
        }
        public IAddressService AddressService  => _addressService.Value;
        public IDispatchDriverService DispatchDriverService  => _dispatchDriverService.Value;
        public IMenuService MenuService  => _menuService.Value;
        public IOrderService OrderService  => _orderService.Value;
        public IRestaurantService RestaurantService  => _restaurantService.Value;
        public IUserService UserService  => _userService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
