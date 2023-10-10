import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopDashboardComponent } from './shop-dashboard/shop-dashboard.component';
import { RouterModule, Routes } from '@angular/router';
import { ShopOrdersComponent } from './shop-orders/shop-orders.component';
import { CustomerModule } from 'src/app/customer/customer.module';

import { OrderscountComponent } from './orderscount/orderscount.component';
import { FormGroup, FormsModule } from '@angular/forms';
import { LineChartComponent } from './shop-dashboard/line-chart/line-chart.component';

export const shopRoutes: Routes = [
  { path: 'dashboard', component: ShopDashboardComponent },
  { path: 'orders', component: ShopOrdersComponent },
 
];

@NgModule({
  declarations: [ShopDashboardComponent, ShopOrdersComponent, OrderscountComponent, LineChartComponent],
  imports: [CommonModule,CustomerModule,RouterModule],
  
})
export class ShopOwnerModule {}
