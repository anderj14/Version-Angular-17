
namespace Core.Entities
{
    public class Vehicle : BaseEntity
    {
        public string VehicleName { get; set; }
        public int Year { get; set; }
        public string Vin { get; set; }
        public int Passengers { get; set; }
        public string Transmission { get; set; }
        public int Doors { get; set; }
        public string Color { get; set; }

        public decimal RentalPrice { get; set; }
        public int FuelConsumption { get; set; }

        public int FuelId { get; set; }
        public Fuel Fuel { get; set; }
        
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public int ModelId { get; set; }
        public Model Model { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

    }
}