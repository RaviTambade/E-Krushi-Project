import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShipperDashboardComponent } from './shipper-dashboard/shipper-dashboard.component';
import { RouterModule, Routes } from '@angular/router';
import { ShipperOrdersComponent } from './shipper-orders/shipper-orders.component';
import { ShipperorderscountComponent } from './shipper-dashboard/shipperorderscount/shipperorderscount.component';
import { LinechartComponent } from './shipper-dashboard/linechart/linechart.component';
import { NgChartsModule } from 'ng2-charts';
import { SharedModule } from '@ekrushi-shared/shared.module';

export const shipperRoutes: Routes = [
  { path: 'dashboard', component: ShipperDashboardComponent },
  { path: 'orders', component: ShipperOrdersComponent },

];

@NgModule({
  declarations: [ShipperDashboardComponent, ShipperOrdersComponent, ShipperorderscountComponent, LinechartComponent],
  imports: [CommonModule,RouterModule,NgChartsModule,SharedModule],
})
export class ShipperModule {}
