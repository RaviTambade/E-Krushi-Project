import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { CustomerModule } from '@ekrushi-customer/customer.module';
import { NgChartsModule } from 'ng2-charts';
import { DognutChartComponent } from './store-dashboard/dognut-chart/dognut-chart.component';
import { LineChartComponent } from './store-dashboard/line-chart/line-chart.component';
import { OrderscountComponent } from './store-dashboard/orderscount/orderscount.component';
import { StoreDashboardComponent } from './store-dashboard/store-dashboard.component';
import { TopSellingProductComponent } from './store-dashboard/top-selling-products/top-selling-product/top-selling-product.component';
import { TopSellingProductsComponent } from './store-dashboard/top-selling-products/top-selling-products.component';
import { StoreOrdersComponent } from './store-orders/store-orders.component';

export const storeRoutes: Routes = [
  { path: 'dashboard', component: StoreDashboardComponent },
  { path: 'orders', component: StoreOrdersComponent },
 
];

@NgModule({
  declarations: [StoreDashboardComponent, StoreOrdersComponent, OrderscountComponent, LineChartComponent, TopSellingProductsComponent, TopSellingProductComponent, DognutChartComponent],
  imports: [CommonModule,CustomerModule,RouterModule,NgChartsModule,FormsModule],
  
})
export class ShopOwnerModule {}
