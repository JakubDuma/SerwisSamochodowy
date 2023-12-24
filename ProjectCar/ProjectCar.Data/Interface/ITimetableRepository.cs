using ProjectCar.Data.Models;

namespace ProjectCar.Data.Interface
{
    public interface ITimetableRepository
    {
        Timetable Create(Timetable timetable);

        void Delete(int id);

        Timetable Get(int id);

        List<Timetable> GetAll();

        void Update(Timetable timetable);
    }
}