using Microsoft.AspNetCore.Mvc;
using ProjectCar.Services.DTO;
using ProjectCar.Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly IPartService _partService;

        public PartController(IPartService partService)
        {
            _partService = partService;
        }

        // GET: api/<PartController>
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            return Ok(_partService.GetAll());
        }

        // GET api/<PartController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_partService.Get(id));
        }

        // POST api/<PartController>
        [HttpPost]
        public IActionResult Post([FromBody] PartDTO part)
        {
            var newPart = _partService.Create(part);
            return CreatedAtAction(nameof(Get), newPart.Id, newPart);
        }

        // PUT api/<PartController>/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] PartDTO part)
        {
            _partService.Update(part);
        }

        // DELETE api/<PartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _partService.Delete(id);
        }
    }
}