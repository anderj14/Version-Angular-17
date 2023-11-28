import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Vehicle } from 'src/app/shared/models/vehicles';
import { VehicleService } from '../vehicle.service';

@Component({
  selector: 'app-vehicle-details',
  templateUrl: './vehicle-details.component.html',
  styleUrls: ['./vehicle-details.component.scss']
})
export class VehicleDetailsComponent implements OnInit {
  vehicle!: Vehicle;

  constructor(private vehicleService: VehicleService, private activateRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.getVehicle();
  }

  getVehicle() {
    const id = this.activateRoute.snapshot.paramMap.get('id');
    if (id) this.vehicleService.getVehicle(+id).subscribe({
      next: vehicle => this.vehicle = vehicle,
      error: error => console.log(error)
    });
  }

}
