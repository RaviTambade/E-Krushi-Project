import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilterdateComponent } from './filterdate/filterdate.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OrderStatusComponent } from './order-status/order-status.component';



@NgModule({
  declarations: [
    FilterdateComponent,
    OrderStatusComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  exports: [
    FilterdateComponent,
    OrderStatusComponent
  ]
})
export class OrderModule { }
