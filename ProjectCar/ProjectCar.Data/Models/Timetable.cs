namespace ProjectCar.Data.Models
{
    public class Timetable
    {
        public int Id { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public string ServiceType { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
    }
}