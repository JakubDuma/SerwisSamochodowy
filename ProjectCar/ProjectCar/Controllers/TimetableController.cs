using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCar.Services.DTO;
using ProjectCar.Services.Interface;
using System.Security.Claims;

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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Post([FromBody] TimetableDTO timetable)
        {//PRZESYŁAĆ TOKEN I RESZTA NA BACKU token
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claim = identity.Claims;
            var userIdClaim = claim.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
            var id = int.Parse(userIdClaim.Value);

            var usernameClaim = claim.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault().Value;

            timetable.UserId = id; timetable.User = usernameClaim; timetable.Name = null; timetable.ExecutionDate = null; timetable.Status = "SERVICE1";

            var newTimetable = _timetableService.Create(timetable);
            return CreatedAtAction(nameof(Get), newTimetable.Id, newTimetable);
        }

        // PUT api/<PartController>/5
        [HttpPut]
        public void Update([FromBody] TimetableDTO timetable)
        {
            _timetableService.Update(timetable);
        }

        [HttpPut]
        public void Reklamacja(int id, string Reason)
        {
            var service = _timetableService.Get(id);
            service.Status = "REKLAMACJA";
            service.ReklaDescription = Reason;
            _timetableService.Update(service);
        }

        // DELETE api/<PartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _timetableService.Delete(id);
        }
    }
}