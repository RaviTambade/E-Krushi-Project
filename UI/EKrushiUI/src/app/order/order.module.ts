import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilterdateComponent } from './filterdate/filterdate.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OrderComponent } from './order/order.component';
import { OrderdetailsComponent } from './orderdetails/orderdetails.component';
import { OrderhistoryComponent } from './orderhistory/orderhistory.component';



@NgModule({
  declarations: [
    FilterdateComponent,
    OrderComponent,
    OrderdetailsComponent,
    OrderhistoryComponent
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
