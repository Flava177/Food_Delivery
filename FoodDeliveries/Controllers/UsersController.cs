using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace FoodDeliveries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager _service;
        public UsersController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetUsers()
        {

            var users = _service.UserService.GetAllUsers(trackChanges: false);
            return Ok(users);

        }


        [HttpGet("{id:guid}")]
        public IActionResult GetUser(string id)
        {
            var user = _service.UserService.GetUser(id, trackChanges: false);
            return Ok(user);
        }
    }
}
