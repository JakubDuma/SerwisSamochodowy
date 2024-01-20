using Microsoft.AspNetCore.Mvc;
using ProjectCar.Services.DTO;
using ProjectCar.Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartTransferController : ControllerBase
    {
        private readonly IPartService _partService;

        public PartTransferController(IPartService partService)
        {
            _partService = partService;
        }

        // POST: api/Part/TransferPart
        [HttpPost("TransferPart/{partId}")]
        public IActionResult TransferPart(int partId, [FromBody] GetPartDTO model)
        {
            var part = _partService.Get(partId);

            if (part == null)
            {
                return NotFound("Część nie została znaleziona");
            }

            // Sprawdź, czy jest wystarczająca ilość części na magazynie
            if (part.WarehouseAvailability < model.QuantityToTransfer)
            {
                return BadRequest("Brak wystarczającej ilości części na magazynie");
            }

            // Przeprowadź transfer części z magazynu na serwis
            part.ServiceAvailability += model.QuantityToTransfer;
            part.WarehouseAvailability -= model.QuantityToTransfer;

            // Odpowiedź zawierająca zaktualizowane dane części
            _partService.Update(part);
            return Ok(part);
        }

        // POST: api/Part/TransferPart
        [HttpPost("AddPart/{partId}")]
        public IActionResult AddPart(int partId, [FromBody] GetPartDTO model)
        {
            var part = _partService.Get(partId);

            if (part == null)
            {
                return NotFound("Część nie została znaleziona");
            }

            // Dodaj część na magazyn
            part.WarehouseAvailability += model.QuantityToTransfer;

            // Odpowiedź zawierająca zaktualizowane dane części
            _partService.Update(part);
            return Ok(part);
        }
    }
}