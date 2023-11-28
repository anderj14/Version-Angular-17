
namespace Core.Entities
{
    public class VehicleType : BaseEntity
    {
        public string VehicleTypeName { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }

    }
}