namespace ProjectCar.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public long? Nip { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}