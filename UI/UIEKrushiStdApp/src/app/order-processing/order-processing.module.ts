import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddressComponent } from './address/address.component';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PaymentComponent } from './payment/payment.component';
import { OrderProcessingMainComponent } from './order-processing-main/order-processing-main.component';
import { SharedModule } from '@ekrushi-shared/shared.module';
import { UpdateAddressComponent } from './update-address/update-address.component';
import { AddAddressComponent } from './add-address/add-address.component';


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
    AddAddressComponent,
    UpdateAddressComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    SharedModule,
 
  ],
})
export class OrderProcessingModule {}
