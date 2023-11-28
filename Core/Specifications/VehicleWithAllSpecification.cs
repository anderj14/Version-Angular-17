
using Core.Entities;

namespace Core.Specifications
{
    public class VehicleWithAllSpecification : BaseSpecification<Vehicle>
    {
        public VehicleWithAllSpecification(VehicleSpecParams vehicleSpecParams)
            : base(x =>
            (string.IsNullOrEmpty(vehicleSpecParams.Search) || x.VehicleName.ToLower().Contains
            (vehicleSpecParams.Search)) &&
            (!vehicleSpecParams.BrandId.HasValue || x.BrandId == vehicleSpecParams.BrandId) &&
            (!vehicleSpecParams.ModelId.HasValue || x.ModelId == vehicleSpecParams.ModelId) &&
            (!vehicleSpecParams.StatusId.HasValue || x.StatusId == vehicleSpecParams.StatusId) &&
            (!vehicleSpecParams.FuelId.HasValue || x.FuelId == vehicleSpecParams.FuelId) &&
            (!vehicleSpecParams.VehicleTypeId.HasValue || x.VehicleTypeId == vehicleSpecParams.VehicleTypeId)
            )
        {
            AddInclude(v => v.Brand);
            AddInclude(v => v.Model);
            AddInclude(v => v.Fuel);
            AddInclude(v => v.Status);
            AddInclude(v => v.VehicleType);

            AddOrderBy(x => x.VehicleName);
            ApplyPaging(vehicleSpecParams.PageSize * (vehicleSpecParams.PageIndex - 1),
            vehicleSpecParams.PageSize);

            if (!string.IsNullOrEmpty(vehicleSpecParams.Sort))
            {
                switch (vehicleSpecParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.RentalPrice);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.RentalPrice);
                        break;
                    default:
                        AddOrderBy(n => n.VehicleName);
                        break;
                }
            }
        }

        public VehicleWithAllSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(v => v.Brand);
            AddInclude(v => v.Model);
            AddInclude(v => v.Fuel);
            AddInclude(v => v.Status);
            AddInclude(v => v.VehicleType);
        }
    }
}