using ProjectCar.Services.DTO;

namespace ProjectCar.Services.Interface
{
    public interface IUserService
    {
        UserDTO Create(UserDTO user);

        void Delete(int id);

        UserDTO Get(int id);

        List<UserDTO> GetAll();

        void Update(UserDTO user);

        string GenerateJwt(LoginDTO dto);

        string GetNameByEmail(LoginDTO dto);

        string GetRoleByEmail(LoginDTO dto);
    }
}