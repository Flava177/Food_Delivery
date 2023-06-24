using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace FoodDeliveries.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class DispatchDriversController : ControllerBase
    {
        private readonly IServiceManager _service;
        public DispatchDriversController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetDrivers()
        {
            var drivers = _service.DispatchDriverService.GetAllDrivers(trackChanges: false);
            return Ok(drivers);

        }


        [HttpGet("{id:guid}", Name ="DispatchById")]
        public IActionResult GetDriver(Guid id)
        {
            var driver = _service.DispatchDriverService.GetDriver(id, trackChanges: false);
            return Ok(driver);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateDriver([FromBody] DispatchDriverForCreationDto dispatch)
        {
            if (dispatch is null) 

                return BadRequest("DispatchDriverForCreationDto object is null");

            var createdDispatch = _service.DispatchDriverService.CreateDriver(dispatch);

            return CreatedAtRoute("DispatchById", new { id = createdDispatch.Id }, createdDispatch);
        }
    }
}
