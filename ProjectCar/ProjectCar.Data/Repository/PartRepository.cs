using ProjectCar.Data.Interface;
using ProjectCar.Data.Models;

namespace ProjectCar.Data.Repository
{
    internal class PartRepository : IPartRepository
    {
        private readonly ProjectCarDBContext _context;

        public PartRepository(ProjectCarDBContext context)
        {
            _context = context;
        }

        public List<Part> GetAll()
        {
            return _context.Parts.ToList();
        }

        public Part Get(int id)
        {
            return _context.Parts.FirstOrDefault(x => x.Id == id);
        }

        public Part Create(Part part)
        {
            _context.Parts.Add(part);
            _context.SaveChanges();
            return part;
        }

        public void Update(Part part)
        {
            _context.Update(part);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Remove(Get(id));
            _context.SaveChanges();
        }
    }
}