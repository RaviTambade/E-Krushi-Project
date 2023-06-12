import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { StoreComponent } from './store/store.component';
import { ProfileComponent } from './profile/profile.component';
import { OrderComponent } from './order/order.component';
import { RoutingComponent } from './routing/routing.component';



@NgModule({
  declarations: [
    HomeComponent,
    StoreComponent,
    ProfileComponent,
    OrderComponent,
    RoutingComponent
  ],
  imports: [
    CommonModule
  ]
})
export class EmployeeModule { }
