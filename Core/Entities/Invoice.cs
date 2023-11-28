
namespace Core.Entities
{
    public class Invoice : BaseEntity
    {
        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public string PaymentType { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}