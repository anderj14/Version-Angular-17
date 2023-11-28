using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ReservationWithFiltersForCountSpecification : BaseSpecification<Reservation>
    {
        public ReservationWithFiltersForCountSpecification(ReservationSpecParams reservationSpecParams)
        : base(x =>
            (string.IsNullOrEmpty(reservationSpecParams.Search) || x.Customer.CustomerName.ToLower().Contains(reservationSpecParams.Search)) &&
            (!reservationSpecParams.CustomerId.HasValue || x.CustomerId == reservationSpecParams.CustomerId) &&
            (!reservationSpecParams.VehicleId.HasValue || x.VehicleId == reservationSpecParams.VehicleId) &&
            (!reservationSpecParams.InsuranceId.HasValue || x.InsuranceId == reservationSpecParams.InsuranceId) &&
            (!reservationSpecParams.StartDate.HasValue || x.StartDate >= reservationSpecParams.StartDate) &&
            (!reservationSpecParams.EndDate.HasValue || x.EndDate <= reservationSpecParams.EndDate)
        )
        {
        }
    }
}