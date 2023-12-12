using ProjectCar.Data.Models;

namespace ProjectCar.Data.Interface
{
    public interface IPartRepository
    {
        Part Create(Part part);

        void Delete(int id);

        Part Get(int id);

        List<Part> GetAll();

        void Update(Part part);
    }
}