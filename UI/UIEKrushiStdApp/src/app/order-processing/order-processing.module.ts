import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddressComponent } from './address/address.component';
import { Routes } from '@angular/router';
import { AddAddressComponent } from './add-address/add-address.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

export const orderProcessingRoutes: Routes = [
  { path: 'address/add', component: AddAddressComponent },
  { path: 'address', component: AddressComponent },
];

@NgModule({
  declarations: [AddressComponent, AddAddressComponent],
  imports: [CommonModule,ReactiveFormsModule,FormsModule],
})
export class OrderProcessingModule {}
