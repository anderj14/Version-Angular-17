

namespace Core.Dtos
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Days { get; set; }
        public decimal RentalCost { get; set; }

        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public int InsuranceId { get; set; }
    }
}