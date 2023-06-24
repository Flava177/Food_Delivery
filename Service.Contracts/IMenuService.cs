using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IMenuService
    {
        IEnumerable<MenuDto> GetAllMenu(Guid restaurantId, bool trackChanges);
        MenuDto GetMenu(Guid restaurantId, Guid id, bool trackChanges);
        MenuDto MenuItemForCreation(Guid restaurantId, MenuItemForCreationDto menuItemForCreation, bool trackChanges);
    }
}
