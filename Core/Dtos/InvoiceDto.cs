
namespace Core.Dtos
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public string PaymentType { get; set; }

        public int CustomerId { get; set; }

        public int ReservationId { get; set; }
    }
}