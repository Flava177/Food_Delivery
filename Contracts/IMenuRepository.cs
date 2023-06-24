using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IMenuRepository
    {
        IEnumerable<MenuItem> GetAllMenus (Guid restaurantId, bool trackChanges);
        MenuItem GetMenu(Guid restaurantId, Guid id, bool trackChanges);
        void CreateMenuItem(Guid restaurantId, MenuItem menuItem);
    }
}
