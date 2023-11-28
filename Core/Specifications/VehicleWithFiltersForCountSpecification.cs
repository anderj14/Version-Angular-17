
using Core.Entities;

namespace Core.Specifications
{
    public class VehicleWithFiltersForCountSpecification : BaseSpecification<Vehicle>
    {
        public VehicleWithFiltersForCountSpecification(VehicleSpecParams vehicleSpecParams)
        : base(x =>
            (string.IsNullOrEmpty(vehicleSpecParams.Search) || x.VehicleName.ToLower()
            .Contains(vehicleSpecParams.Search)) &&
            (!vehicleSpecParams.BrandId.HasValue || x.BrandId == vehicleSpecParams.BrandId) &&
            (!vehicleSpecParams.ModelId.HasValue || x.ModelId == vehicleSpecParams.ModelId) &&
            (!vehicleSpecParams.StatusId.HasValue || x.StatusId == vehicleSpecParams.StatusId) &&
            (!vehicleSpecParams.FuelId.HasValue || x.FuelId == vehicleSpecParams.FuelId) &&
            (!vehicleSpecParams.VehicleTypeId.HasValue || x.VehicleTypeId == vehicleSpecParams.VehicleTypeId)
            )
        {
        }
    }
}