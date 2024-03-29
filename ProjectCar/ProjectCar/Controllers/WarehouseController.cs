﻿using Microsoft.AspNetCore.Mvc;
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

        public WarehouseController(IPartService partService)
        {
            _partService = partService;
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
    }
}
