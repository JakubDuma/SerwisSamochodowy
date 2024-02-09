using Microsoft.AspNetCore.Mvc;
using ProjectCar.Services.DTO;
using ProjectCar.Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<PartController>
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            return Ok(_userService.GetAll());
        }

        // GET api/<PartController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_userService.Get(id));
        }

        // POST api/<PartController>
        [HttpPost]
        public IActionResult Post([FromBody] UserDTO user)
        {
            var newUser = _userService.Create(user);
            return CreatedAtAction(nameof(Get), newUser.Id, newUser);
        }

        // PUT api/<PartController>/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] UserDTO user)
        {
            _userService.Update(user);
        }

        // DELETE api/<PartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userService.Delete(id);
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO dto)
        {
            string role = _userService.GetRoleByEmail(dto);
            string name = _userService.GetNameByEmail(dto);
            string token = _userService.GenerateJwt(dto);
            int id = _userService.GetIdByEmail(dto);
            return Ok(new { Success = true, Token = token, Name = name, Role = role, Id = id }); //token imie i rola
        }
    }
}