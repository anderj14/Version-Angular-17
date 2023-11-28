
namespace Core.Dtos
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string VehicleName { get; set; }
        public int Year { get; set; }
        public string Vin { get; set; }
        public int Passengers { get; set; }
        public string Transmission { get; set; }
        public int Doors { get; set; }
        public string Color { get; set; }

        public decimal RentalPrice { get; set; }
        public int FuelConsumption { get; set; }

        public string Fuel { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Status { get; set; }

        public string VehicleType { get; set; }
    }
}