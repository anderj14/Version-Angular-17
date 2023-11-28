
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.VehiclesDtos
{
    public class CreateVehicleDto
    {

        [Required]
        public string VehicleName { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Vin { get; set; }

        [Required]
        public int Passengers { get; set; }

        [Required]
        public string Transmission { get; set; }

        [Required]
        public int Doors { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public decimal RentalPrice { get; set; }

        [Required]
        public int FuelConsumption { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        public int ModelId { get; set; }

        [Required]
        public int FuelId { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required]
        public int VehicleTypeId { get; set; }
    }
}