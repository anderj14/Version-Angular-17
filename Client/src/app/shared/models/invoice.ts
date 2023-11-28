import { Customer } from "./customers"
import { Reservation } from "./reservation"

export interface Invoice {
    id: number
    totalAmount: number
    date: string
    paymentType: string
    customerId: number
    reservationId: number
    customer?: Customer
    reservation?: Reservation
}
