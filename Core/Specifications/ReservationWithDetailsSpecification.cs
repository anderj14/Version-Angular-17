using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ReservationWithDetailsSpecification : BaseSpecification<Reservation>
    {
        public ReservationWithDetailsSpecification(ReservationSpecParams reservationSpecParams)
        : base(x =>
            (string.IsNullOrEmpty(reservationSpecParams.Search) || x.Customer.CustomerName.ToLower().Contains(reservationSpecParams.Search)) &&
            (!reservationSpecParams.CustomerId.HasValue || x.CustomerId == reservationSpecParams.CustomerId) &&
            (!reservationSpecParams.VehicleId.HasValue || x.VehicleId == reservationSpecParams.VehicleId) &&
            (!reservationSpecParams.InsuranceId.HasValue || x.InsuranceId == reservationSpecParams.InsuranceId) &&
            (!reservationSpecParams.StartDate.HasValue || x.StartDate >= reservationSpecParams.StartDate) &&
            (!reservationSpecParams.EndDate.HasValue || x.EndDate <= reservationSpecParams.EndDate)
        )
        {
            AddInclude(r => r.Customer);
            AddInclude(r => r.Vehicle);
            AddInclude(r => r.Insurance);

            ApplyPaging(reservationSpecParams.PageSize * (reservationSpecParams.PageIndex - 1), reservationSpecParams.PageSize);

            if (!string.IsNullOrEmpty(reservationSpecParams.Sort))
            {
                switch (reservationSpecParams.Sort)
                {
                    // Agrega más casos según sea necesario
                    default:
                        AddOrderBy(r => r.StartDate);
                        break;
                }
            }
        }
        public ReservationWithDetailsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(r => r.Customer);
            AddInclude(r => r.Vehicle);
            AddInclude(r => r.Insurance);
        }
    }
}