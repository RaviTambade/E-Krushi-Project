import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerDashboardComponent } from './customer-dashboard/customer-dashboard.component';
import { Routes } from '@angular/router';

export const customerRoutes: Routes = [
  { path: 'dashboard', component: CustomerDashboardComponent },
];

@NgModule({
  declarations: [CustomerDashboardComponent],
  imports: [CommonModule],
})
export class CustomerModule {}
