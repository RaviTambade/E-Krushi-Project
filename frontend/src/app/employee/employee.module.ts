import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { StoreComponent } from './store/store.component';
import { ProfileComponent } from './profile/profile.component';
import { OrderComponent } from './order/order.component';
import { RoutingComponent } from './routing/routing.component';
import { RouterModule, Routes } from '@angular/router';

const routes : Routes=[
  {path:'home', component:HomeComponent},
  {path:'order', component:OrderComponent },
  {path:'profile', component:ProfileComponent},
  {path:'store', component:StoreComponent},
]

@NgModule({
  declarations: [
    HomeComponent,
    StoreComponent,
    ProfileComponent,
    OrderComponent,
    RoutingComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RoutingComponent
  ]
})
export class EmployeeModule { }


