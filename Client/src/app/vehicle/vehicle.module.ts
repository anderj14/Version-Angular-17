import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VehicleComponent } from './vehicle.component';
import { VehicleDetailsComponent } from './vehicle-details/vehicle-details.component';
import { VehicleItemComponent } from './vehicle-item/vehicle-item.component';
import { RouterModule } from '@angular/router';
import { VehicleRoutingModule } from './vehicle-routing.module';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    VehicleComponent,
    VehicleDetailsComponent,
    VehicleItemComponent
  ],
  imports: [
    CommonModule,
    VehicleRoutingModule,
    SharedModule
  ]
})
export class VehicleModule { }
