using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Data
{
    public class RentalContextSeed
    {
        public static async Task SeedAsync(RentalContext context)
        { 
// 1
            if (!context.Brands.Any())
            {
                var brandData = File.ReadAllText("../Infrastructure/Data/SeedData/brand.json");
                var brand = JsonSerializer.Deserialize<List<Brand>>(brandData);

                context.Brands.AddRange(brand);
            }
// 2
            if (!context.Customers.Any())
            {
                var customerData = File.ReadAllText("../Infrastructure/Data/SeedData/customer.json");
                var customer = JsonSerializer.Deserialize<List<Customer>>(customerData);

                context.Customers.AddRange(customer);
            }
// 3
            if (!context.Fuels.Any())
            {
                var fuelData = File.ReadAllText("../Infrastructure/Data/SeedData/fuel.json");
                var fuel = JsonSerializer.Deserialize<List<Fuel>>(fuelData);

                context.Fuels.AddRange(fuel);
            }
// 4
            if (!context.Insurances.Any())
            {
                var insuranceData = File.ReadAllText("../Infrastructure/Data/SeedData/insurance.json");
                var insurance = JsonSerializer.Deserialize<List<Insurance>>(insuranceData);

                context.Insurances.AddRange(insurance);
            }
// 5
            if (!context.Invoices.Any())
            {
                var invoiceData = File.ReadAllText("../Infrastructure/Data/SeedData/invoice.json");
                var invoice = JsonSerializer.Deserialize<List<Invoice>>(invoiceData);

                context.Invoices.AddRange(invoice);
            }

            if (!context.Models.Any())
            {
                var modelData = File.ReadAllText("../Infrastructure/Data/SeedData/model.json");
                var model = JsonSerializer.Deserialize<List<Model>>(modelData);

                context.Models.AddRange(model);
            }
// 6
            if (!context.Reservations.Any())
            {
                var reservationData = File.ReadAllText("../Infrastructure/Data/SeedData/reservation.json");
                var reservation = JsonSerializer.Deserialize<List<Reservation>>(reservationData);

                context.Reservations.AddRange(reservation);
            }
// 7
            if (!context.Statuses.Any())
            {
                var statusData = File.ReadAllText("../Infrastructure/Data/SeedData/status.json");
                var status = JsonSerializer.Deserialize<List<Status>>(statusData);

                context.Statuses.AddRange(status);
            }
// 8
            if (!context.Vehicles.Any())
            {
                var vehicleData = File.ReadAllText("../Infrastructure/Data/SeedData/vehicle.json");
                var vehicle = JsonSerializer.Deserialize<List<Vehicle>>(vehicleData);

                context.Vehicles.AddRange(vehicle);
            }
// 9                                                                    /Infrastructure/Data/SeedData
            if (!context.VehicleTypes.Any())
            {
                var vehicleTypeData = File.ReadAllText("../Infrastructure/Data/SeedData/vehicletype.json");
                var vehicleType = JsonSerializer.Deserialize<List<VehicleType>>(vehicleTypeData);

                context.VehicleTypes.AddRange(vehicleType);
            }

            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}