
namespace Core.Entities
{
    public class Reservation : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Days { get; set; }
        public decimal RentalCost { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }


        public int InsuranceId { get; set; }
        public Insurance Insurance { get; set; }

        public ICollection<Invoice> Invoices { get; set; }

    }
}