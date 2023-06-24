using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal sealed class MenuRepository : RepositoryBase<MenuItem>, IMenuRepository
    {
        public MenuRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public IEnumerable<MenuItem> GetAllMenus(bool trackChanges) =>
            FindAll(trackChanges)
               .OrderBy(c => c.Name)
               .ToList();

        public MenuItem GetMenu(Guid menuItemId, bool trackChanges)
        {
            var menuItem = FindByCondition(c => c.Id.Equals(menuItemId), trackChanges)
                .SingleOrDefault() ?? throw new Exception("menu not found.");
            return menuItem;
        }
    }
}
