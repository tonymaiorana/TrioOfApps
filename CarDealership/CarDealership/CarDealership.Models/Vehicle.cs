using System;

namespace CarDealership.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string AdTitle { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string PictureUrl { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsNew { get; set; }
        public int AdminAccountId { get; set; }
    }
}