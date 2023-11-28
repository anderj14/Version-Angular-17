import { Component, Input } from '@angular/core';
import { Reservation } from 'src/app/shared/models/reservation';

@Component({
  selector: 'app-reservation-item',
  templateUrl: './reservation-item.component.html',
  styleUrls: ['./reservation-item.component.scss']
})
export class ReservationItemComponent {
  @Input() reservations!: Reservation[];

}
