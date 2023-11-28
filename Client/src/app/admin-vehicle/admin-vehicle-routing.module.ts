import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminVehicleComponent } from './admin-vehicle.component';
import { EditVehicleComponent } from './edit-vehicle/edit-vehicle.component';

const routes: Routes = [
  {path: '', component: AdminVehicleComponent},
  {path: 'create', component: EditVehicleComponent, data: {breadcrumb: 'Create'}},
  {path: 'edit/:id', component: EditVehicleComponent, data: {breadcrumb: 'Edit'}},
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class AdminVehicleRoutingModule { }
