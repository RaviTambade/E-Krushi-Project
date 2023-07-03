import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderpaymentComponent } from './orderpayment/orderpayment.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { DebitcardComponent } from './debitcard/debitcard.component';
import { AccountComponent } from './account/account.component';



@NgModule({
  declarations: [
    OrderpaymentComponent,
    DebitcardComponent,
    AccountComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  exports:[
    OrderpaymentComponent,
    DebitcardComponent
  ]
})
export class PaymentModule { }
