import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagerComponent } from './pager/pager.component';
import { PagingHeaderComponent } from './paging-header/paging-header.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TextInputComponent } from './components/text-input/text-input.component';
import { CurrencyMaskModule } from 'ng2-currency-mask';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    PagerComponent,
    PagingHeaderComponent,
    TextInputComponent,
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    ReactiveFormsModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    CurrencyMaskModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule
  ],
  exports: [
    PagerComponent,
    PagingHeaderComponent,
    ReactiveFormsModule,
    BsDropdownModule,
    TextInputComponent,
    CurrencyMaskModule,
    FormsModule,
    ReactiveFormsModule,
    TextInputComponent
  ]
})
export class SharedModule { }
