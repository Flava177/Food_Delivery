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
    internal sealed class MenuService : IMenuService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public MenuService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<MenuDto> GetAllMenu(bool trackChanges)
        {

            var menuItems = _repository.Menu.GetAllMenus(trackChanges);

            var menuItemsDto = menuItems.Select(c =>

            new MenuDto(c.Id, c.Name, c.Description, c.Price)).ToList();

            return menuItemsDto;

        }

        public MenuDto GetMenu(Guid id, bool trackChanges)
        {
            var menuItem = _repository.Menu.GetMenu(id, trackChanges);


            var menuItemDto = new MenuDto(
                id,
                menuItem.Name,
                menuItem.Description,
                menuItem.Price
                );

            return menuItemDto;
        }

    }
}
