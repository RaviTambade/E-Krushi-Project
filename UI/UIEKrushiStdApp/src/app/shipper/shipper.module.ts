import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShipperDashboardComponent } from './shipper-dashboard/shipper-dashboard.component';
import { Routes } from '@angular/router';

export const shipperRoutes: Routes = [
  { path: 'dashboard', component: ShipperDashboardComponent },
];

@NgModule({
  declarations: [ShipperDashboardComponent],
  imports: [CommonModule],
})
export class ShipperModule {}
