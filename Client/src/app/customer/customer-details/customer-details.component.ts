import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Customer } from 'src/app/shared/models/customers';
import { CustomerService } from '../customer.service';

@Component({
  selector: 'app-customer-details',
  templateUrl: './customer-details.component.html',
  styleUrls: ['./customer-details.component.scss']
})
export class CustomerDetailsComponent {
  customer!: Customer;

  constructor(private customerService: CustomerService, private activateRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadVehicle();
  }

  loadVehicle() {
    const id = this.activateRoute.snapshot.paramMap.get('id');
    if (id) this.customerService.getCustomer(+id).subscribe({
      next: customer => this.customer = customer,
      error: error => console.log(error)
    });
  }
}
