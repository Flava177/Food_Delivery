using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager 
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IRestaurantRepository> _restaurantRepository;
        private readonly Lazy<IMenuRepository> _menuRepository;
        private readonly Lazy<IOrderRepository> _orderRepository;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IAddressRepository> _addressRepository;
        private readonly Lazy<IDispatchDriverRepository> _dispatchDriverRepository ;
        private readonly Lazy<IStatus> _status ;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

            _restaurantRepository = new Lazy<IRestaurantRepository>(() => new RestaurantRepository(repositoryContext));
            _menuRepository = new Lazy<IMenuRepository>(() => new MenuRepository(repositoryContext));
            _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(repositoryContext));
            //_userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _addressRepository = new Lazy<IAddressRepository>(() => new AddressRepository(repositoryContext));
            _dispatchDriverRepository = new Lazy<IDispatchDriverRepository>(() => new DispatchDriverRepository(repositoryContext));
            _status = new Lazy<IStatus>(() => new StatusRepository(repositoryContext));
        } 
        public IRestaurantRepository Restaurant => _restaurantRepository.Value;
        public IMenuRepository Menu => _menuRepository.Value;
        public IOrderRepository Order => _orderRepository.Value;
        public IUserRepository User => _userRepository.Value;
        public IAddressRepository Address => _addressRepository.Value;
        public IDispatchDriverRepository DispatchDriver => _dispatchDriverRepository.Value;
        public IStatus StatusValue => _status.Value;

        public void Save() => _repositoryContext.SaveChanges(); }
}
