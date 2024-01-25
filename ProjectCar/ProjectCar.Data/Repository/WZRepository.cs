using ProjectCar.Data.Interface;
using ProjectCar.Data.Models;

namespace ProjectCar.Data.Repository
{
    internal class WZRepository : IWZRepository
    {
        private readonly ProjectCarDBContext _context;

        public WZRepository(ProjectCarDBContext context)
        {
            _context = context;
        }

        public WZ Get(int id)
        {
            return _context.WZ.FirstOrDefault(u => u.Id == id);
        }

        public WZ Create(WZ wz)
        {
            _context.WZ.Add(wz);
            _context.SaveChanges();
            return wz;
        }
    }
}