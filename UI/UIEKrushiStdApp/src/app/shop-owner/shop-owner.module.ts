import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopDashboardComponent } from './shop-dashboard/shop-dashboard.component';
import { RouterModule, Routes } from '@angular/router';
import { ShopOrdersComponent } from './shop-orders/shop-orders.component';
import { CustomerModule } from 'src/app/customer/customer.module';

import { OrderscountComponent } from './shop-dashboard/orderscount/orderscount.component';
import { LineChartComponent } from './shop-dashboard/line-chart/line-chart.component';
import { NgChartsModule } from 'ng2-charts';

export const shopRoutes: Routes = [
  { path: 'dashboard', component: ShopDashboardComponent },
  { path: 'orders', component: ShopOrdersComponent },
 
];

@NgModule({
  declarations: [ShopDashboardComponent, ShopOrdersComponent, OrderscountComponent, LineChartComponent],
  imports: [CommonModule,CustomerModule,RouterModule,NgChartsModule],
  
})
export class ShopOwnerModule {}
