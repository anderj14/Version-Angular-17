
using AutoMapper;
using Core.Dtos;
using Core.Dtos.VehiclesDtos;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Vehicle, VehicleDto>()
            .ForMember(d => d.Fuel, o => o.MapFrom(s => s.Fuel.FuelName))
            .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.BrandName))
            .ForMember(d => d.Model, o => o.MapFrom(s => s.Model.ModelName))
            .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.StatusName))
            .ForMember(d => d.VehicleType, o => o.MapFrom(s => s.VehicleType.VehicleTypeName));

            CreateMap<Fuel, FuelDto>();
            CreateMap<Brand, BrandDto>();

            CreateMap<Model, ModelDto>()
            .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.BrandName));

            CreateMap<Status, StatusDto>();
            CreateMap<VehicleType, VehicleTypeDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<Insurance, InsuranceDto>();
            CreateMap<Reservation, ReservationDto>();
            CreateMap<Invoice, InvoiceDto>();

            CreateMap<Address, AddressDto>().ReverseMap();

            // Add
            CreateMap<CreateVehicleDto, Vehicle>();
        }
    }
}