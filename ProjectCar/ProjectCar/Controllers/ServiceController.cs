using Microsoft.AspNetCore.Mvc;
using ProjectCar.Services.DTO;
using ProjectCar.Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IOrderStatusService _statusService;

        public ServiceController(IOrderStatusService statusService)
        {
            _statusService = statusService;
        }

        // PUT api/<ServiceController>/5
        [HttpPut]
        public IActionResult UpdateOrderStatus([FromBody] OrderStatusDTO status)
        {
            _statusService.Update(status);
            return Ok();
        }

        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
