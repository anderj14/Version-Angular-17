
using Core.Entities;

namespace Core.Specifications
{
    public class CustomerWithFilterForCountSpecification : BaseSpecification<Customer>
    {
        public CustomerWithFilterForCountSpecification(CustomerSpecParams customerSpecParams)
        : base(x =>
        (string.IsNullOrEmpty(customerSpecParams.Search) || x.CustomerName.ToLower().Contains
                (customerSpecParams.Search))
        )
        {
        }
    }
}