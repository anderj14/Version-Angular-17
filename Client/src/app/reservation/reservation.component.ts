import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Reservation } from '../shared/models/reservation';
import { ReservationService } from './reservation.service';
import { ReservationParams } from '../shared/models/reservationParams';

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.scss']
})
export class ReservationComponent implements OnInit {
  @ViewChild('search') searchTerm?: ElementRef;

  reservations!: Reservation[];
  reservationParams = new ReservationParams();
  sortOption = [
    { name: 'Alphabetical', value: 'reservation' },
    { name: 'Price: Low To High', value: 'priceAsc' },
    { name: 'Price: High To Low', value: 'priceDesc' },
  ];
  totalCount = 0;

  constructor(private reservationService: ReservationService) { }

  ngOnInit(): void {
    this.getReservations();
  }

  getReservations() {
    this.reservationService.getReservations(this.reservationParams)
      .subscribe(response => {
        this.reservations = response.data;
        this.reservationParams.pageNumber = response.pageIndex;
        this.reservationParams.pageSize = response.pageSize;
        this.totalCount = response.count;

        this.reservations.forEach(reservation => {
          this.reservationService.getCustomerById(reservation.customerId)
            .subscribe(customer => {
              reservation.customer = customer;
            });
          this.reservationService.getVehicleById(reservation.vehicleId)
            .subscribe(vehicle => {
              reservation.vehicle = vehicle;
            });
          this.reservationService.getInsuranceById(reservation.insuranceId)
            .subscribe(insurance => {
              reservation.insurance = insurance;
            });
        });
      });
  }

  onSortSelected(event: any) {
    this.reservationParams.sort = event.target.value;
    this.getReservations();
  }

  onPageChanged(event: any) {
    if (this.reservationParams.pageNumber !== event) {
      this.reservationParams.pageNumber = event;
      this.getReservations();
    }
  }

  onSearch() {
    this.reservationParams.search = this.searchTerm?.nativeElement.value;
    this.reservationParams.pageNumber = 1;
    this.getReservations();
  }

  onReset() {
    if (this.searchTerm) this.searchTerm.nativeElement.value = '';
    this.reservationParams = new ReservationParams();
    this.getReservations();
  }

}
