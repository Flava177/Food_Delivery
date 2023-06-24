using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class MenuService : IMenuService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public MenuService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<MenuDto> GetAllMenu(Guid restaurantId, bool trackChanges)
        {
            var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges);
            if (restaurant is null) 
                throw new RestaurantNotFoundException(restaurantId);


            var menuFromDb = _repository.Menu.GetAllMenus(restaurantId, trackChanges);

            var menuDto = menuFromDb.Select(c =>

            new MenuDto(c.Id, c.Name, c.Description, c.Price)).ToList();

            return menuDto;

        }
    
        public MenuDto GetMenu(Guid restaurantId, Guid id, bool trackChanges)
        {
            var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges);
            if (restaurant is null) throw new RestaurantNotFoundException(restaurantId);

            var menuDb = _repository.Menu.GetMenu(restaurantId, id, trackChanges);
            if  (menuDb is null) throw new MenuNotFoundException(id);

            var menu = new MenuDto(
                Id: menuDb.Id,
                Name: menuDb.Name,
                Description: menuDb.Description,
                Price: menuDb.Price
            );
            return menu;
        }


        public MenuDto MenuItemForCreation(Guid restaurantId, MenuItemForCreationDto menuItemForCreation, bool trackChanges)
        {
            var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges) ?? throw new RestaurantNotFoundException(restaurantId);
            var menuEntity = new MenuItem
            {
                Id = Guid.NewGuid(),
                RestaurantId = restaurantId,
                Name = menuItemForCreation.Name,
                Description = menuItemForCreation.Description,
                Price = menuItemForCreation.Price
            };

            _repository.Menu.CreateMenuItem(restaurantId, menuEntity);
            _repository.Save();

            var menuToReturn = new MenuDto(
               menuEntity.Id,
               menuEntity.Name,
               menuEntity.Description,
               menuEntity.Price
           );

            return menuToReturn;
        }

    }
}
