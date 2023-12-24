using ProjectCar.Data.Interface;
using ProjectCar.Data.Models;

namespace ProjectCar.Data.Repository
{
    internal class TimetableRepository : ITimetableRepository
    {
        private readonly ProjectCarDBContext _context;

        public TimetableRepository(ProjectCarDBContext context)
        {
            _context = context;
        }

        public List<Timetable> GetAll()
        {
            return _context.Timetables.ToList();
        }

        public Timetable Get(int id)
        {
            return _context.Timetables.FirstOrDefault(x => x.Id == id);
        }

        public Timetable Create(Timetable timetable)
        {
            _context.Timetables.Add(timetable);
            _context.SaveChanges();
            return timetable;
        }

        public void Update(Timetable timetable)
        {
            _context.Update(timetable);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Remove(Get(id));
            _context.SaveChanges();
        }
    }
}