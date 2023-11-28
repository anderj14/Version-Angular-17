import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerComponent } from './customer.component';
import { CustomerItemComponent } from './customer-item/customer-item.component';
import { CustomerDetailsComponent } from './customer-details/customer-details.component';
import { CustomerRoutingModule } from './customer-routing.module';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    CustomerComponent,
    CustomerItemComponent,
    CustomerDetailsComponent
  ],
  imports: [
    CommonModule,
    CustomerRoutingModule,
    SharedModule
  ]
})
export class CustomerModule { }
