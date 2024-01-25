using ProjectCar.Data.Models;

namespace ProjectCar.Data.Interface
{
    public interface IWZRepository
    {
        WZ Get(int id);

        WZ Create(WZ wz);
    }
}