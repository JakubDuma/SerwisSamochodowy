using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using ProjectCar.Data.Authentication;
using ProjectCar.Data.Interface;
using ProjectCar.Data.Models;
using ProjectCar.Services.DTO;
using ProjectCar.Services.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectCar.Services.Service
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly AuthenticationSettings _authenticationSettings;

        public UserService(IUserRepository userRepository, IMapper mapper, AuthenticationSettings authentication)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authenticationSettings = authentication;
        }

        public UserDTO Create(UserDTO user)
        {
            var newUser = _mapper.Map<User>(user);
            _userRepository.Create(newUser);
            return _mapper.Map<UserDTO>(newUser);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public UserDTO Get(int id)
        {
            var user = _userRepository.Get(id);
            return _mapper.Map<UserDTO>(user);
        }

        public List<UserDTO> GetAll()
        {
            var users = _userRepository.GetAll();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public void Update(UserDTO user)
        {
            var updateUser = _mapper.Map<User>(user);
            _userRepository.Update(updateUser);
        }

        public string GenerateJwt(LoginDTO dto)
        {
            var user = _userRepository.GenerateJwt(dto.Email);
            if (user.Password != dto.Password)
            {
                throw new Exception("Błędne hasło");
            }
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}