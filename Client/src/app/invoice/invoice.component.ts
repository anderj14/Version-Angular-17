import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Invoice } from '../shared/models/invoice';
import { InvoiceParams } from '../shared/models/invoiceParams';
import { InvoiceService } from './invoice.service';
import { VehicleService } from '../vehicle/vehicle.service';

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.scss']
})
export class InvoiceComponent implements OnInit {
  @ViewChild('search') searchTerm?: ElementRef;

  invoices!: Invoice[];
  invoiceParams = new InvoiceParams();
  sortOption = [
    { name: 'Alphabetical', value: 'reservation' },
    { name: 'Price: Low To High', value: 'priceAsc' },
    { name: 'Price: High To Low', value: 'priceDesc' },
  ];
  totalCount = 0;

  constructor(
    private invoiceService: InvoiceService,
    private vehicleService: VehicleService
  ) {}
  ngOnInit(): void {
    this.getInvoices();
  }

  getInvoices() {
    this.invoiceService.getInvoices(this.invoiceParams)
      .subscribe(response => {
        this.invoices = response.data;
        this.invoiceParams.pageNumber = response.pageIndex;
        this.invoiceParams.pageSize = response.pageSize;
        this.totalCount = response.count;

        this.invoices.forEach(invoice => {
          this.invoiceService.getCustomerById(invoice.customerId)
            .subscribe(customer => {
              invoice.customer = customer;
            });

          this.invoiceService.getReservationById(invoice.reservationId)
            .subscribe(reservation => {
              invoice.reservation = reservation;

              // Ahora, carga detalles del vehículo
              if (reservation?.vehicleId) {
                this.vehicleService.getVehicle(reservation.vehicleId)
                  .subscribe(vehicle => {
                    reservation.vehicle = vehicle;
                  });
              }
              if (reservation?.vehicleId) {
                this.invoiceService.getInsuranceById(reservation.vehicleId)
                  .subscribe(insurance => {
                    reservation.insurance = insurance;
                  });
              }
            });
        });
      });
  }

  
  onSortSelected(event: any) {
    this.invoiceParams.sort = event.target.value;
    this.getInvoices();
  }

  onPageChanged(event: any) {
    if (this.invoiceParams.pageNumber !== event) {
      this.invoiceParams.pageNumber = event;
      this.getInvoices();
    }
  }

  onSearch() {
    this.invoiceParams.search = this.searchTerm?.nativeElement.value;
    this.invoiceParams.pageNumber = 1;
    this.getInvoices();
  }

  onReset() {
    if (this.searchTerm) this.searchTerm.nativeElement.value = '';
    this.invoiceParams = new InvoiceParams();
    this.getInvoices();
  }

}
