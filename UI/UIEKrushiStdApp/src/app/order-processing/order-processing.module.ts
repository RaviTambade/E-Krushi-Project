import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddressComponent } from './address/address.component';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PaymentComponent } from './payment/payment.component';
import { OrderProcessingMainComponent } from './order-processing-main/order-processing-main.component';
import { SharedModule } from '@ekrushi-shared/shared.module';
import { MembershipLibModule } from 'membership-lib';

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
    PaymentComponent,
    OrderProcessingMainComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    SharedModule,
    MembershipLibModule,
  ],
})
export class OrderProcessingModule {}
