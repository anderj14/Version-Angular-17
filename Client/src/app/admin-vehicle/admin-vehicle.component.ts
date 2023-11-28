import { Component, OnInit } from '@angular/core';
import { Vehicle } from '../shared/models/vehicles';
import { VehicleParams } from '../shared/models/vehicleParams';
import { VehicleService } from '../vehicle/vehicle.service';
import { EditVehicleService } from './edit-vehicle.service';

@Component({
  selector: 'app-admin-vehicle',
  templateUrl: './admin-vehicle.component.html',
  styleUrls: ['./admin-vehicle.component.scss']
})
export class AdminVehicleComponent implements OnInit {

  vehicles!: Vehicle[];
  totalCount!: number;
  vehicleParams: VehicleParams;

  constructor(private vehicleService: VehicleService, private editVehicleService: EditVehicleService) {
    this.vehicleParams = this.vehicleService.getVehicleParams();
  }
  ngOnInit(): void {
    this.getVehicles();
  }

  getVehicles() {
    this.vehicleService.getVehicles(this.vehicleParams).subscribe({
      next: response => {
        this.vehicles = response.data;
        this.totalCount = response.count;
      },
      error: error => console.log(error)
    });
  }

  onPageChanged(event: any) {
    const params = this.vehicleService.getVehicleParams();
    if (params.pageNumber !== event) {
      params.pageNumber = event;
      this.vehicleService.setVehicleParams(params);
      this.getVehicles();
    }
  }

  deleteVehicle(id: number) {
    this.editVehicleService.deleteVehicle(id).subscribe((response: any) => {
      this.vehicles.splice(this.vehicles.findIndex(p => p.id === id), 1);
      this.totalCount--;
    });
  }

}
