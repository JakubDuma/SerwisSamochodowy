namespace ProjectCar.Services.DTO
{
    public class PartDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int InServiceDisposal { get; set; }
        public int Price { get; set; }
        public decimal Margin { get; set; }
    }
}