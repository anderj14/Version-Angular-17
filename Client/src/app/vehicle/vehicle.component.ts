import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Vehicle } from '../shared/models/vehicles';
import { Brand } from '../shared/models/brand';
import { Model } from '../shared/models/model';
import { Fuel } from '../shared/models/fuel';
import { Status } from '../shared/models/status';
import { VehicleType } from '../shared/models/vehicleType';
import { VehicleParams } from '../shared/models/vehicleParams';
import { VehicleService } from './vehicle.service';
import { Observable } from 'rxjs';
import { User } from '../shared/models/user';
import { AccountService } from '../account/account.service';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.scss']
})
export class VehicleComponent implements OnInit {

  @ViewChild('search') searchTerm?: ElementRef;
  vehicles!: Vehicle[];
  brands!: Brand[];
  models!: Model[];
  fuels!: Fuel[];
  statuses!: Status[];
  vehiclesType!: VehicleType[];
  vehicleParams = new VehicleParams();
  sortOption = [
    { name: 'Alphabetical', value: 'vehicleName' },
    { name: 'Price: Low To High', value: 'priceAsc' },
    { name: 'Price: High To Low', value: 'priceDesc' },
  ];
  totalCount = 0;

  currentUser$!: Observable<User>;
  isAdmin$!: Observable<boolean>;

  constructor(private vehicleService: VehicleService, private accountService: AccountService) { }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
    this.isAdmin$ = this.accountService.isAdmin$;

    this.getVehicles();
    this.getBrands();
    this.getModels();
    this.getFuels();
    this.getStatuses();
    this.getVehiclesType();
  }


  getVehicles() {
    this.vehicleService.getVehicles(this.vehicleParams).subscribe({
      next: response => {
        this.vehicles = response.data;
        this.vehicleParams.pageNumber = response.pageIndex;
        this.vehicleParams.pageSize = response.pageSize;
        this.totalCount = response.count;
      },
      error: error => console.log(error)
    });
  }

  getBrands() {
    this.vehicleService.getBrands().subscribe({
      next: response => this.brands = [{ id: 0, brandName: 'All' }, ...response],
      error: error => console.log(error)
    });
  }
  getModels() {
    this.vehicleService.getModels().subscribe({
      next: response => this.models = [{ id: 0, modelName: 'All' }, ...response],
      error: error => console.log(error)
    });
  }

  getFuels() {
    this.vehicleService.getFuels().subscribe({
      next: response => this.fuels = [{ id: 0, fuelName: 'All' }, ...response],
      error: error => console.log(error)
    });
  }

  getStatuses() {
    this.vehicleService.getStatutes().subscribe({
      next: response => this.statuses = [{ id: 0, statusName: 'All' }, ...response],
      error: error => console.log(error)
    });
  }

  getVehiclesType() {
    this.vehicleService.getVehiclesType().subscribe({
      next: response => this.vehiclesType = [{ id: 0, vehicleTypeName: 'All' }, ...response],
      error: error => console.log(error)
    });
  }

  onBrandSelected(brandId: number) {
    this.vehicleParams.brandId = brandId;
    this.vehicleParams.pageNumber = 1;
    this.getVehicles();
  }

  onModelSelected(modelId: number) {
    this.vehicleParams.modelId = modelId;
    this.vehicleParams.pageNumber = 1;
    this.getVehicles();
  }

  onFuelSelected(fuelId: number) {
    this.vehicleParams.fuelId = fuelId;
    this.vehicleParams.pageNumber = 1;
    this.getVehicles();
  }

  onStatusSelected(statusId: number) {
    this.vehicleParams.statusId = statusId;
    this.vehicleParams.pageNumber = 1;
    this.getVehicles();
  }

  onVehicleTypeSelected(vehicleTypeId: number) {
    this.vehicleParams.vehicleTypeId = vehicleTypeId;
    this.vehicleParams.pageNumber = 1;
    this.getVehicles();
  }


  onSortSelected(event: any) {
    this.vehicleParams.sort = event.target.value;
    this.getVehicles();
  }

  onPageChanged(event: any) {
    if (this.vehicleParams.pageNumber !== event) {
      this.vehicleParams.pageNumber = event;
      this.getVehicles();
    }
  }

  onSearch() {
    this.vehicleParams.search = this.searchTerm?.nativeElement.value;
    this.vehicleParams.pageNumber = 1;
    this.getVehicles();
  }

  onReset() {
    if (this.searchTerm) this.searchTerm.nativeElement.value = '';
    this.vehicleParams = new VehicleParams();
    this.getVehicles();
  }


  showPopup = false;

  togglePopup() {
    this.showPopup = !this.showPopup;
  }

  closePopup() {
    this.showPopup = false;
  }
  stopPropagation(event: Event) {
    event.stopPropagation(); // Evitar que el clic llegue al popup-overlay
  }

  getStatusClass(status: string): string {
    const lowercaseStatus = status.toLowerCase();
  
    switch (lowercaseStatus) {
      case 'available':
        return 'available';
      case 'rented':
        return 'rented';
      case 'reserved':
        return 'reserved';
      default:
        return '';
    }
  }
}
