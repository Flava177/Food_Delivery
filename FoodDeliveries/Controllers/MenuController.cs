using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace FoodDeliveries.Controllers
{

    [Authorize]
    [Route("api/restaurants/{restaurantId}/menus")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IServiceManager _service;
        public MenusController(IServiceManager service) => _service = service;


        [HttpGet]
        public IActionResult GetMenus(Guid restaurantId)
        {

            var menus = _service.MenuService.GetAllMenu(restaurantId, trackChanges: false);
            return Ok(menus);

        }


        [HttpGet("{id:guid}", Name = "MenuById")]
        public IActionResult GetMenu(Guid restaurantId, Guid id)
        {
            var menu = _service.MenuService.GetMenu(restaurantId, id, trackChanges: false);
            return Ok(menu);
        }

        [Authorize(Roles = "Admin")]
        [Authorize]
        public IActionResult CreateMenuForRestaurant(Guid restaurantId, [FromBody] MenuItemForCreationDto menuItem)
        {
            if (menuItem is null) 
                return BadRequest("MenuItemForCreationDto object is null");

            var menuToReturn = _service.MenuService.MenuItemForCreation(restaurantId, menuItem, trackChanges: false);
            return CreatedAtRoute("MenuById", 
                new { restaurantId, id = menuToReturn.Id },
                menuToReturn);
        }
    }
}
