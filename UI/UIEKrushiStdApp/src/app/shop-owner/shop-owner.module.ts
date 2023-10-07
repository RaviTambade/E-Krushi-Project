import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopDashboardComponent } from './shop-dashboard/shop-dashboard.component';
import { RouterModule, Routes } from '@angular/router';
import { ShopOrdersComponent } from './shop-orders/shop-orders.component';
import { CustomerModule } from 'src/app/customer/customer.module';
import { ShopOrderDetailsComponent } from './shop-orders/shop-order-details/shop-order-details.component';

export const shopRoutes: Routes = [
  { path: 'dashboard', component: ShopDashboardComponent },
  { path: 'orders', component: ShopOrdersComponent },
  {
    path:'orders/details/:orderid', component:ShopOrderDetailsComponent
  }
];

@NgModule({
  declarations: [ShopDashboardComponent, ShopOrdersComponent,ShopOrderDetailsComponent],
  imports: [CommonModule,CustomerModule,RouterModule],
})
export class ShopOwnerModule {}
