using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class InvoiceWithFiltersForCountSpecification : BaseSpecification<Invoice>
    {
        public InvoiceWithFiltersForCountSpecification(InvoiceSpecParams invoiceSpecParams)
                    : base(x =>
                (string.IsNullOrEmpty(invoiceSpecParams.Search) || x.Customer.CustomerName.ToLower().Contains(invoiceSpecParams.Search)) &&
                (!invoiceSpecParams.CustomerId.HasValue || x.CustomerId == invoiceSpecParams.CustomerId) &&
                (!invoiceSpecParams.ReservationId.HasValue || x.ReservationId == invoiceSpecParams.ReservationId)
            )
        {
        }
    }
}