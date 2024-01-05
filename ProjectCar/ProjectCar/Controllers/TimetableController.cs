using Microsoft.AspNetCore.Mvc;
using ProjectCar.Services.DTO;
using ProjectCar.Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimetableController : ControllerBase
    {
        private readonly ITimetableService _timetableService;

        public TimetableController(ITimetableService TimetableService)
        {
            _timetableService = TimetableService;
        }

        // GET: api/<PartController>
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            return Ok(_timetableService.GetAll());
        }

        // GET api/<PartController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_timetableService.Get(id));
        }

        // POST api/<PartController>
        [HttpPost]
        public IActionResult Post([FromBody] TimetableDTO timetable)
        {
            var newTimetable = _timetableService.Create(timetable);
            return CreatedAtAction(nameof(Get), newTimetable.Id, newTimetable);
        }

        // PUT api/<PartController>/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] TimetableDTO timetable)
        {
            _timetableService.Update(timetable);
        }

        // DELETE api/<PartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _timetableService.Delete(id);
        }
    }
}