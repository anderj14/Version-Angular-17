import { Component, Input } from '@angular/core';
import { Vehicle } from 'src/app/shared/models/vehicles';

@Component({
  selector: 'app-vehicle-item',
  templateUrl: './vehicle-item.component.html',
  styleUrls: ['./vehicle-item.component.scss']
})
export class VehicleItemComponent {
  @Input() vehicles!: Vehicle[];
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
