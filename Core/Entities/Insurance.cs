
namespace Core.Entities
{
    public class Insurance: BaseEntity
    {
        public string InsuranceName { get; set; }
        public decimal InsurancePrice { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}