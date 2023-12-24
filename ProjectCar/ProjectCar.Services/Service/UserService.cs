using AutoMapper;
using ProjectCar.Data.Interface;
using ProjectCar.Data.Models;
using ProjectCar.Services.DTO;
using ProjectCar.Services.Interface;

namespace ProjectCar.Services.Service
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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
    }
}