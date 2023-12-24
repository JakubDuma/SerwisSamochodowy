namespace ProjectCar.Services.DTO
{
    public class TimetableDTO
    {
        public List<UserDTO> User { get; }
        public DateOnly Date { get; set; }
        public DateTime Time { get; set; }
    }
}