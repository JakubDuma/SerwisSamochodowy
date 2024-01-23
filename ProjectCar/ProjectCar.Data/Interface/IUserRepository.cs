using ProjectCar.Data.Models;

namespace ProjectCar.Data.Interface
{
    public interface IUserRepository
    {
        User Create(User user);

        void Delete(int id);

        User Get(int id);

        List<User> GetAll();

        void Update(User user);
    }
}