import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SupplierDashboardComponent } from './supplier-dashboard/supplier-dashboard.component';
import { Routes } from '@angular/router';
import { AddProductComponent } from './add-product/add-product.component';
import { ReactiveFormsModule } from '@angular/forms';


export const supplierRoutes: Routes = [
  { path: 'dashboard', component: SupplierDashboardComponent },
];
@NgModule({
  declarations: [
    SupplierDashboardComponent,
    AddProductComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ]
})
export class SupplierModule { }
