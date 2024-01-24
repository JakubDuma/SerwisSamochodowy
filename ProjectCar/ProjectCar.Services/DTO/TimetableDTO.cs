namespace ProjectCar.Services.DTO
{
    public class TimetableDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string User { get; set; }
        public DateTime OrderDate { get; set; }
        public string? Name { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public string? Status { get; set; }
    }
}