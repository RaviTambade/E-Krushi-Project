import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddressComponent } from './address/address.component';
import { RouterModule, Routes } from '@angular/router';
import { AddAddressComponent } from './add-address/add-address.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddressMainComponent } from './address-main/address-main.component';
import { PaymentComponent } from './payment/payment.component';

export const orderProcessingRoutes: Routes = [
  {
    path: 'address',
    component: AddressMainComponent,
  },
  {
    path:'payment',
    component:PaymentComponent
  }
];

@NgModule({
  declarations: [AddressComponent, AddAddressComponent, AddressMainComponent, PaymentComponent],
  imports: [CommonModule, ReactiveFormsModule, FormsModule, RouterModule],
})
export class OrderProcessingModule {}
