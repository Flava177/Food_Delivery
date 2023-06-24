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
        IEnumerable<MenuDto> GetAllMenu(bool trackChanges);
        MenuDto GetMenu(Guid menuItemId, bool trackChanges);
    }
}
