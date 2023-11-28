
namespace Core.Entities
{
    public class Model : BaseEntity
    {
        public string ModelName { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}