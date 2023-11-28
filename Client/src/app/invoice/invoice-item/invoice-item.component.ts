import { Component, Input } from '@angular/core';
import { Invoice } from 'src/app/shared/models/invoice';

@Component({
  selector: 'app-invoice-item',
  templateUrl: './invoice-item.component.html',
  styleUrls: ['./invoice-item.component.scss']
})
export class InvoiceItemComponent {
  @Input() invoices!: Invoice[];
}
