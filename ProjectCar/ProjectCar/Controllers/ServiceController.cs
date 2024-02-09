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
        private readonly IPartService _partService;

        public ServiceController(IOrderStatusService statusService, ITimetableService TimetableService, IPartService partservice)
        {
            _statusService = statusService;
            _timetableService = TimetableService;
            _partService = partservice;
        }

        // PUT api/<ServiceController>/5
        [HttpPut]
        public IActionResult UpdateOrderStatus([FromBody] OrderStatusDTO status)
        {
            status.Status = "WAREHOUSE";
            status.ExecutionDate = DateTime.Now;
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
        public IActionResult EndOrder([FromBody] IdDTO id)
        {
            var order = _timetableService.Get(id.Id);
            order.Status = "FINISHED";
            _timetableService.Update(order);
            _partService.CreateWZ(order);
            return Ok();
        }
    }
}