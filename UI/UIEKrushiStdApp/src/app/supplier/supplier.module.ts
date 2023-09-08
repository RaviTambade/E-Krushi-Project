import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SupplierDashboardComponent } from './supplier-dashboard/supplier-dashboard.component';
import { Routes } from '@angular/router';


export const supplierRoutes: Routes = [
  { path: 'dashboard', component: SupplierDashboardComponent },
];
@NgModule({
  declarations: [
    SupplierDashboardComponent
  ],
  imports: [
    CommonModule
  ]
})
export class SupplierModule { }
