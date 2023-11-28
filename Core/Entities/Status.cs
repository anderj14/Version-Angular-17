
namespace Core.Entities
{
    public class Status: BaseEntity
    {
        public string StatusName { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}