using Microsoft.AspNetCore.Identity;
using ProjectCar.Data.Interface;
using ProjectCar.Data.Models;

namespace ProjectCar.Data.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly ProjectCarDBContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserRepository(ProjectCarDBContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Get(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public User Create(User user)
        {
            //var hashedPassword = _passwordHasher.HashPassword(user, user.Password);
            //user.Password = hashedPassword;
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void Update(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Remove(Get(id));
            _context.SaveChanges();
        }

        public User Login(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}