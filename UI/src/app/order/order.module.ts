import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilterdateComponent } from './filterdate/filterdate.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OrderComponent } from './order/order.component';
import { OrderdetailsComponent } from './orderdetails/orderdetails.component';



@NgModule({
  declarations: [
    FilterdateComponent,
    OrderComponent,
    OrderdetailsComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  exports: [
    FilterdateComponent,
    OrderComponent,
    OrderdetailsComponent
  ]
})
export class OrderModule { }
