namespace ProjectCar.Services.DTO
{
    public class TimetableDTO
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public string ServiceType { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
    }
}