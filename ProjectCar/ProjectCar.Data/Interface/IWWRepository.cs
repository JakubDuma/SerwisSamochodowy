using ProjectCar.Data.Models;

namespace ProjectCar.Data.Interface
{
    public interface IWWRepository
    {
        WW Get(int id);
        WW Create(WW ww);
    }
}
