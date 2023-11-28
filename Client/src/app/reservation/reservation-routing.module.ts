import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReservationComponent } from './reservation.component';
import ReservationDetailsComponent from './reservation-details/reservation-details.component';

const routes: Routes = [
  { path: '', component: ReservationComponent },
  { path: ':id', component: ReservationDetailsComponent }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class ReservationRoutingModule { }
