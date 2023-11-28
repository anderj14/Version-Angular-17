import { Component, Input } from '@angular/core';
import { Customer } from 'src/app/shared/models/customers';

@Component({
  selector: 'app-customer-item',
  templateUrl: './customer-item.component.html',
  styleUrls: ['./customer-item.component.scss']
})
export class CustomerItemComponent {
  @Input() customers!: Customer[];

}
