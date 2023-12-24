namespace ProjectCar.Data.Models
{
    public class Timetable
    {
        public List<User> User { get; }
        public DateOnly Date { get; set; }
        public DateTime Time { get; set; }
    }
}