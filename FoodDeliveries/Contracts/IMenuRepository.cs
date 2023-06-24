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
        IEnumerable<MenuItem> GetAllMenus (bool trackChanges);
        MenuItem GetMenu(Guid menuItemId, bool trackChanges);
    }
}
