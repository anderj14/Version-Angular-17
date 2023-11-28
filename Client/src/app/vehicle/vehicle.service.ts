import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { VehicleParams } from '../shared/models/vehicleParams';
import { Pagination } from '../shared/models/Pagination';
import { Vehicle } from '../shared/models/vehicles';
import { Brand } from '../shared/models/brand';
import { Model } from '../shared/models/model';
import { Status } from '../shared/models/status';
import { Fuel } from '../shared/models/fuel';
import { VehicleType } from '../shared/models/vehicleType';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {
  baseUrl = 'https://localhost:5001/api/';
  vehicleParams = new VehicleParams();

  constructor(private http: HttpClient) { }

  getVehicles(vehicleParams: VehicleParams) {
    let params = new HttpParams();

    if (vehicleParams.brandId > 0) params = params.append('brandId', vehicleParams.brandId);
    if (vehicleParams.modelId) params = params.append('modelId', vehicleParams.modelId);
    if (vehicleParams.fuelId) params = params.append('fuelId', vehicleParams.fuelId);
    if (vehicleParams.statusId) params = params.append('statusId', vehicleParams.statusId);
    if (vehicleParams.vehicleTypeId) params = params.append('vehicleTypeId', vehicleParams.vehicleTypeId);
    params = params.append('sort', vehicleParams.sort);
    params = params.append('pageIndex', vehicleParams.pageNumber);
    params = params.append('pageSize', vehicleParams.pageSize);
    if (vehicleParams.search) params = params.append('search', vehicleParams.search);

    return this.http.get<Pagination<Vehicle[]>>(this.baseUrl + 'vehicles', { params });
  }

  setVehicleParams(params: VehicleParams) {
    this.vehicleParams = params;
  }

  getVehicleParams() {
    return this.vehicleParams;
  }

  getVehicle(id: number){
    return this.http.get<Vehicle>(this.baseUrl + 'vehicles/' + id);
  }

  getBrands() {
    return this.http.get<Brand[]>(this.baseUrl + 'brands');
  }

  getModels() {
    return this.http.get<Model[]>(this.baseUrl + 'models');
  }

  getFuels() {
    return this.http.get<Fuel[]>(this.baseUrl + 'fuels');
  }

  getStatutes() {
    return this.http.get<Status[]>(this.baseUrl + 'statuses');
  }

  getVehiclesType() {
    return this.http.get<VehicleType[]>(this.baseUrl + 'vehiclesType');
  }

}
