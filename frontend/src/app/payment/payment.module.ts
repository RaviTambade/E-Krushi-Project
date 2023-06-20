import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderpaymentComponent } from './orderpayment/orderpayment.component';



@NgModule({
  declarations: [
    OrderpaymentComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    OrderpaymentComponent
  ]
})
export class PaymentModule { }
