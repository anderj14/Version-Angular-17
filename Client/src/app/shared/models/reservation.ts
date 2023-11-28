import { Customer } from "./customers"
import { Insurance } from "./insurance"
import { Vehicle } from "./vehicles"

export interface Reservation {
    id: number
    startDate: string
    endDate: string
    days: number
    rentalCost: number
    customerId: number
    vehicleId: number
    insuranceId: number
    customer?: Customer; 
    vehicle?: Vehicle; 
    insurance?: Insurance; 
}
