import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderpaymentComponent } from './orderpayment/orderpayment.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [
    OrderpaymentComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  exports:[
    OrderpaymentComponent
  ]
})
export class PaymentModule { }
