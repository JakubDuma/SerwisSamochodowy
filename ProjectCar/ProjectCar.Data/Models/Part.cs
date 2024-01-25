namespace ProjectCar.Data.Models
{
    public class Part
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; } //WarehouseDisposal
        public int InServiceDisposal { get; set; }
        public int Price { get; set; }
        public decimal Margin { get; set; }
    }
}