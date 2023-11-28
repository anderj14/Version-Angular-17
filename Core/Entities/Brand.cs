namespace Core.Entities
{
    public class Brand : BaseEntity
    {
        public string BrandName { get; set; }
        public ICollection<Model> Models { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}