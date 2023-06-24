using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class MenuNotFoundException : NotFoundException
    {
        public MenuNotFoundException(Guid menuId) : base($"Menu with id: {menuId} doesn't exist in the restaurant.")
        {
        } 
    }
}
