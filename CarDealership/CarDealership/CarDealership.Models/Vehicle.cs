using System;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        [RegularExpression(@"\d{4}", ErrorMessage = "Please make sure to enter a valid 4 digit year.")]
        public int Year { get; set; }

        public int Mileage { get; set; }

        [Required]
        public string AdTitle { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        public string PictureUrl { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public bool IsNew { get; set; }
    }
}