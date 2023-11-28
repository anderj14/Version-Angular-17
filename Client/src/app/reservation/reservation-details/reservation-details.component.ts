import { Component, OnInit } from '@angular/core';
import { Reservation } from 'src/app/shared/models/reservation';
import { ReservationService } from '../reservation.service';
import { ActivatedRoute } from '@angular/router';
import { Customer } from 'src/app/shared/models/customers';
import { Vehicle } from 'src/app/shared/models/vehicles';
import { Insurance } from 'src/app/shared/models/insurance';

@Component({
  selector: 'app-reservation-details',
  templateUrl: './reservation-details.component.html',
  styleUrls: ['./reservation-details.component.scss']
})
export default class ReservationDetailsComponent implements OnInit {
  reservation!: Reservation;
  customer!: Customer;
  vehicle!: Vehicle;
  insurance!: Insurance;

  constructor(private reservationService: ReservationService, private activateRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.getReservation();
  }

  getReservation() {
    const id = this.activateRoute.snapshot.paramMap.get('id');
    if (id) {
      this.reservationService.getReservation(+id).subscribe({
        next: reservation => {
          this.reservation = reservation;
          this.getCustomer(reservation.customerId);
          this.getVehicle(reservation.vehicleId);
          this.getInsurance(reservation.insuranceId);
        },
        error: error => console.log(error)
      });
    }
  }

  getCustomer(customerId: number) {
    this.reservationService.getCustomerById(customerId).subscribe({
      next: customer => this.customer = customer,
      error: error => console.log(error)
    });
  }
  getVehicle(vehicleId: number) {
    this.reservationService.getVehicleById(vehicleId).subscribe({
      next: vehicle => this.vehicle = vehicle,
      error: error => console.log(error)
    });
  }
  getInsurance(insuranceId: number) {
    this.reservationService.getInsuranceById(insuranceId).subscribe({
      next: insurance => this.insurance = insurance,
      error: error => console.log(error)
    });
  }

}
