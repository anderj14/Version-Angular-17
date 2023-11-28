import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { VehicleFormValues } from '../shared/models/vehicles';

@Injectable({
  providedIn: 'root'
})
export class EditVehicleService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  createVehicle(vehicle: VehicleFormValues) {
    return this.http.post(this.baseUrl + 'vehicles', vehicle);
  }

  updateVehicle(vehicle: VehicleFormValues, id: number) {
    return this.http.put(this.baseUrl + 'vehicles/' + id, vehicle);
  }

  deleteVehicle(id: number) {
    return this.http.delete(this.baseUrl + 'vehicles/' + id);
  }

}
