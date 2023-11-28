import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReservationParams } from '../shared/models/reservationParams';
import { Reservation } from '../shared/models/reservation';
import { Pagination } from '../shared/models/Pagination';
import { Observable } from 'rxjs';
import { Customer } from '../shared/models/customers';
import { Insurance } from '../shared/models/insurance';
import { Vehicle } from '../shared/models/vehicles';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getReservations(reservationParams: ReservationParams): Observable<Pagination<Reservation[]>> {
    let params = new HttpParams();

    params = params.append('sort', reservationParams.sort);
    params = params.append('pageIndex', reservationParams.pageNumber);
    params = params.append('pageSize', reservationParams.pageSize);
    if (reservationParams.search) params = params.append('search', reservationParams.search);

    return this.http.get<Pagination<Reservation[]>>(this.baseUrl + 'reservations', { params });
  }


  getReservation(id: number): Observable<Reservation> {
    return this.http.get<Reservation>(this.baseUrl + 'reservations/' + id);
  }

  getCustomerById(customerId: number): Observable<Customer> {
    return this.http.get<Customer>(`${this.baseUrl}customers/${customerId}`);
  }
  getVehicleById(vehicleId: number): Observable<Vehicle> {
    return this.http.get<Vehicle>(`${this.baseUrl}vehicles/${vehicleId}`);
  }
  getInsuranceById(insuranceId: number): Observable<Insurance> {
    return this.http.get<Insurance>(`${this.baseUrl}insurances/${insuranceId}`);
  }
}
