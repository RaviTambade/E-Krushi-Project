import { NgModule } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { StoreComponent } from './store/store.component';
import { ProfileComponent } from './profile/profile.component';
import { OrderComponent } from './order/order.component';
import { RoutingComponent } from './routing/routing.component';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { ProductdetailsComponent } from './productdetails/productdetails.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AddtocartComponent } from '../employee/addtocart/addtocart.component';
import { MycartComponent } from './mycart/mycart.component';
import { UpdateComponent } from './update/update.component';
import { GetCartDetailsComponent } from './get-cart-details/get-cart-details.component';

const routes : Routes=[
  {path:'home', component:HomeComponent},
  {path:'order', component:OrderComponent },
  {path:'profile', component:ProfileComponent},
  {path:'store', component:StoreComponent},
  {path:'store/details/:id', component:ProductdetailsComponent},
  {path:'store/details/:id/addtocart/:id', component:AddtocartComponent},
  {path:'mycart', component:MycartComponent},
  {path:'mycart/update/:id', component:UpdateComponent}
]

@NgModule({
  declarations: [
    HomeComponent,
    StoreComponent,
    ProfileComponent,
    OrderComponent,
    RoutingComponent,
    ProductdetailsComponent,
    AddtocartComponent,
    MycartComponent,
    UpdateComponent,
    GetCartDetailsComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RoutingComponent,
    StoreComponent,
    OrderComponent
  ]
})

export class EmployeeModule { }


