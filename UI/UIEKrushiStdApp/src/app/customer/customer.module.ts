import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerDashboardComponent } from './customer-dashboard/customer-dashboard.component';
import { RouterModule, Routes } from '@angular/router';
import { CustomerOrdersComponent } from './customer-orders/customer-orders.component';
import { CustomerWishlistComponent } from './customer-wishlist/customer-wishlist.component';
import { CustomerPaymenthistoryComponent } from './customer-paymenthistory/customer-paymenthistory.component';
import { DeliveredOrdersComponent } from './customer-orders/delivered-orders/delivered-orders.component';
import { PendingOrdersComponent } from './customer-orders/pending-orders/pending-orders.component';
import { CancelledOrdersComponent } from './customer-orders/cancelled-orders/cancelled-orders.component';

export const customerRoutes: Routes = [
  { path: 'dashboard', component: CustomerDashboardComponent },
  {
    path: 'orders',
    component: CustomerOrdersComponent,
    children: [
      { path: 'delivered', component: DeliveredOrdersComponent },
      { path: 'pending', component: PendingOrdersComponent },
      { path: 'cancelled', component: CancelledOrdersComponent },
    ],
  },
  { path: 'paymentlist', component: CustomerPaymenthistoryComponent },
  { path: 'wishlist', component: CustomerWishlistComponent },
];

@NgModule({
  declarations: [
    CustomerDashboardComponent,
    CustomerOrdersComponent,
    CustomerWishlistComponent,
    CustomerPaymenthistoryComponent,
    DeliveredOrdersComponent,
    PendingOrdersComponent,
    CancelledOrdersComponent,
  ],
  imports: [CommonModule,RouterModule],
})
export class CustomerModule {}
