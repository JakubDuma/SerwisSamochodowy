using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCar.Services.Interface;
using System.Net;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetMyOrders([FromHeader] Authorization token)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            return Ok(_timetableService.GetMyOrders(int.Parse(identity.FindFirst("NameIdentifier").Value)));
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GeneratePDF()
        {
            return Ok(200);
        }
    }
}