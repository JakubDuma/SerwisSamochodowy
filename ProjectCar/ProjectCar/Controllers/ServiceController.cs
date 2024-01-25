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
        private readonly ITimetableService _timetableService;

        public ServiceController(IOrderStatusService statusService, ITimetableService TimetableService)
        {
            _statusService = statusService;
            _timetableService = TimetableService;
        }

        // PUT api/<ServiceController>/5
        [HttpPut]
        public IActionResult UpdateOrderStatus([FromBody] OrderStatusDTO status)
        {
            status.Status = "WAREHOUSE";
            _statusService.Update(status);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetServiceOrders([FromBody] string status)
        {
            return Ok(_statusService.GetWorkingOrders(status));
        }

        [HttpPut]
        [Route("EndOrder")]
        public IActionResult EndOrder([FromBody] int orderId)
        {
            var order = _timetableService.Get(orderId);
            order.Status = "FINISHED";
            _timetableService.Update(order);
            return Ok();
        }

        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}