export interface Vehicle {
    id: number
    vehicleName: string
    year: number
    vin: string
    passengers: number
    transmission: string
    doors: number
    color: string
    rentalPrice: number
    fuelConsumption: number
    brand: string
    model: string
    fuel: string
    status: string
    vehicleType: string
}

export interface IVehicleToCreate {
    vehicleName: string
    year: number
    vin: string
    passengers: number
    transmission: string
    doors: number
    color: string
    rentalPrice: number
    fuelConsumption: number
    brandId: number
    modelId: number
    fuelId: number
    statusId: number
    vehicleTypeId: number
}

export class VehicleFormValues implements IVehicleToCreate {
    vehicleName = '';
    year = 0;
    vin = '';
    passengers = 0;
    transmission = '';
    doors = 0;
    color = '';
    rentalPrice = 0;
    fuelConsumption = 0;
    brandId!: number;
    modelId!: number;
    fuelId!: number;
    statusId!: number;
    vehicleTypeId!: number;

    constructor(init?: VehicleFormValues) {
        Object.assign(this, init);
    }
}