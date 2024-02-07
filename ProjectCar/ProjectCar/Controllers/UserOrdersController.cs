using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCar.Services.Interface;
using QuestPDF.Fluent;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOrdersController : ControllerBase
    {
        private readonly ITimetableService _timetableService;

        public UserOrdersController(ITimetableService TimetableService)
        {
            _timetableService = TimetableService;
        }

        [HttpGet]
        [Route("Test")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetMyOrders()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claim = identity.Claims;
            var userIdClaim = claim
            .Where(x => x.Type == ClaimTypes.NameIdentifier)
            .FirstOrDefault();
            var a = userIdClaim.Value;

            return Ok(_timetableService.GetMyOrders(int.Parse(a)));
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GeneratePDF()
        {
            Document.Create(container =>
            {
            });
            return Ok(200);
        }
    }
}