using ProjectCar.Data.Interface;
using ProjectCar.Data.Models;

namespace ProjectCar.Data.Repository
{
    internal class WWRepository : IWWRepository
    {
        private readonly ProjectCarDBContext _context;

        public WWRepository(ProjectCarDBContext context)
        {
            _context = context;
        }
        public WW Get(int id)
        {
            return _context.WW.FirstOrDefault(u => u.Id == id);
        }

        public WW Create(WW ww)
        {
            _context.WW.Add(ww);
            _context.SaveChanges();
            return ww;
        }
    }
}
