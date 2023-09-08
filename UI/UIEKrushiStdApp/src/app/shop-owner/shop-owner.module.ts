import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopDashboardComponent } from './shop-dashboard/shop-dashboard.component';
import { Routes } from '@angular/router';

export const shopRoutes: Routes = [
  { path: 'dashboard', component: ShopDashboardComponent },
];

@NgModule({
  declarations: [ShopDashboardComponent],
  imports: [CommonModule],
})
export class ShopOwnerModule {}
