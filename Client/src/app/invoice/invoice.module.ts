import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InvoiceComponent } from './invoice.component';
import { InvoiceItemComponent } from './invoice-item/invoice-item.component';
import { InvoiceDetailsComponent } from './invoice-details/invoice-details.component';
import { InvoiceRoutingModule } from './invoice-routing.module';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    InvoiceComponent,
    InvoiceItemComponent,
    InvoiceDetailsComponent
  ],
  imports: [
    CommonModule,
    InvoiceRoutingModule,
    SharedModule
  ]
})
export class InvoiceModule { }
