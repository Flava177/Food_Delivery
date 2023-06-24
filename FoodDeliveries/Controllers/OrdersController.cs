using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace FoodDeliveries.Controllers
{
    [Authorize]
    [Route("api/restaurants/{restaurantId}/menus/{menuId}/orders")]
    //[Route("api/[Controller]/action")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IServiceManager _service;
        public OrdersController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetOrders()
        {

            var orders = _service.OrderService.GetAllOrders(trackChanges: false);
            return Ok(orders);

        }


        [HttpGet("{id:guid}", Name = "OrderById")]
        public IActionResult GetOrder(Guid id)
        {
            var order = _service.OrderService.GetOrder(id, trackChanges: false);
            return Ok(order);
        }


        [HttpPost]
        [Authorize(Roles ="Admin")]
        public IActionResult CreateOrderForMenu([FromBody] OrderForCreationDto orderFor)
        { 
            if (orderFor is null) 

                return BadRequest("OrderForCreationDto object is null"); 
            var orderForToReturn = _service.OrderService.CreateOrderForMenu( orderFor, trackChanges: false);

            return CreatedAtRoute("OrderById", new {
                 id = orderForToReturn.Id
            },
            orderForToReturn);
        }

    }
}
