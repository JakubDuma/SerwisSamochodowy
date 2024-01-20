﻿namespace ProjectCar.Services.DTO
{
    public class PartDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int ServiceAvailability { get; set; }
        public int WarehouseAvailability { get; set; }
    }
}