using ProjectCar.Services.DTO;

namespace ProjectCar.Services.Interface
{
    public interface ITimetableService
    {
        TimetableDTO Create(TimetableDTO timetable);

        void Delete(int id);

        TimetableDTO Get(int id);

        List<TimetableDTO> GetAll();

        void Update(TimetableDTO timetable);

        List<TimetableDTO> GetMyOrders(int id);
    }
}