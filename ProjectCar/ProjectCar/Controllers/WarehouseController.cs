using Microsoft.AspNetCore.Mvc;
using ProjectCar.Services.DTO;
using ProjectCar.Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IPartService _partService;
        private readonly IOrderStatusService _statusService;
        private readonly ITimetableService _timetableService;

        public WarehouseController(IPartService partService, IOrderStatusService statusService, ITimetableService TimetableService)
        {
            _partService = partService;
            _statusService = statusService;
            _timetableService = TimetableService;
        }

        [HttpPut]
        public IActionResult UpdateQuantity([FromBody] PartTransferDTO transfer)
        {
            var part = _partService.Get(transfer.PartId);
            part.Quantity -= transfer.PartQuantity;
            part.InServiceDisposal += transfer.PartQuantity;
            _partService.Update(part);
            _partService.CreateWW(part, part.Quantity);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetWarehouseOrders([FromBody] string status)
        {
            return Ok(_statusService.GetWorkingOrders(status));
        }

        [HttpPut]
        [Route("ChangeToService2Status")]
        public IActionResult ChangeStatus([FromBody] IdDTO id)
        {
            var order = _timetableService.Get(id.Id);
            order.Status = "SERVICE2";
            _timetableService.Update(order);
            return Ok();
        }
    }
}