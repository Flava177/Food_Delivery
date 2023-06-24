using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

        public IEnumerable<MenuItem> GetAllMenus(Guid restaurantId, bool trackChanges) 
            => FindByCondition(e => e.RestaurantId.Equals(restaurantId), trackChanges)
            .OrderBy(m => m.Name)
            .ToList();


        public MenuItem GetMenu(Guid restaurantId, Guid id, bool trackChanges) =>
            FindByCondition(e => e.RestaurantId.Equals(restaurantId) && e.Id.Equals(id), trackChanges).SingleOrDefault();


        public void CreateMenuItem(Guid restaurantId, MenuItem menuItem) 
        {
            menuItem.RestaurantId = restaurantId;

            Create(menuItem);
        }

    }
}
