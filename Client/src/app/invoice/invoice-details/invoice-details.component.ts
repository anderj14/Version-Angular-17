import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { InvoiceService } from '../invoice.service';
import { Customer } from 'src/app/shared/models/customers';
import { Reservation } from 'src/app/shared/models/reservation';
import { Invoice } from 'src/app/shared/models/invoice';
import { Vehicle } from 'src/app/shared/models/vehicles';
import { VehicleService } from 'src/app/vehicle/vehicle.service';
import { Insurance } from 'src/app/shared/models/insurance';

@Component({
  selector: 'app-invoice-details',
  templateUrl: './invoice-details.component.html',
  styleUrls: ['./invoice-details.component.scss']
})
export class InvoiceDetailsComponent implements OnInit {

  invoice!: Invoice;
  reservation!: Reservation;
  customer!: Customer;
  vehicle!: Vehicle; 
  insurance!: Insurance;
  
  constructor(private invoiceService: InvoiceService, 
    private vehicleService: VehicleService, 
    private activateRoute: ActivatedRoute
    ) { }

  ngOnInit(): void {
    this.getInvoice();
  }


  getInvoice() {
    const id = this.activateRoute.snapshot.paramMap.get('id');
    if (id) {
      this.invoiceService.getInvoice(+id).subscribe({
        next: invoice => {
          this.invoice = invoice;
          this.getReservation(invoice.reservationId);
          this.getCustomer(invoice.customerId);
        },
        error: error => console.log(error)
      });
    }
  }

  getCustomer(customerId: number) {
    this.invoiceService.getCustomerById(customerId).subscribe({
      next: customer => this.customer = customer,
      error: error => console.log(error)
    });
  }

  getReservation(reservationId: number) {
    this.invoiceService.getReservationById(reservationId).subscribe({
      next: reservation => {
        this.reservation = reservation;

        // Ahora, carga detalles del vehículo
        if (reservation?.vehicleId) {
          this.vehicleService.getVehicle(reservation.vehicleId)
            .subscribe(vehicle => {
              this.vehicle = vehicle;
            });
        }
        if (reservation?.insuranceId) {
          this.invoiceService.getInsuranceById(reservation.insuranceId)
            .subscribe(insurance => {
              this.insurance = insurance;
            });
        }
      },
      error: error => console.log(error)
    });
  }
}
