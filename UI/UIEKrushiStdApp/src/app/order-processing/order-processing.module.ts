import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddressComponent } from './address/address.component';
import { RouterModule, Routes } from '@angular/router';
import { AddAddressComponent } from './add-address/add-address.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PaymentComponent } from './payment/payment.component';
import { OrderProcessingMainComponent } from './order-processing-main/order-processing-main.component';
import { CustomerModule } from '../customer/customer.module';
import { OrderDetailsComponent } from './order-details/order-details.component';
import { OrderSummeryComponent } from './order-summery/order-summery.component';

export const orderProcessingRoutes: Routes = [
  {
    path: 'payment',
    component: PaymentComponent,
  },
  {
    path: '**',
    component: OrderProcessingMainComponent,
  },
];

@NgModule({
  declarations: [
    AddressComponent,
    AddAddressComponent,
    PaymentComponent,
    OrderProcessingMainComponent,
    OrderDetailsComponent,
    OrderSummeryComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    CustomerModule,
  ],
})
export class OrderProcessingModule {}
