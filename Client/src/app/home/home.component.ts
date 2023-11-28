import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  vehiclesCount = 10;
  customersCount = 20;
  reservationsCount = 30;

}
