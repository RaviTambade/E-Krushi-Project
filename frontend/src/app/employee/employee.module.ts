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
import { OrderpaymentComponent } from '../payment/orderpayment/orderpayment.component';
import { OrderhistoryComponent } from './orderhistory/orderhistory.component';
import { OrderdetailsComponent } from './orderdetails/orderdetails.component';
import { QuestionComponent } from '../consulting/question/question.component';
import { DetailsComponent } from '../consulting/details/details.component';
import { AddquestionComponent } from '../consulting/addquestion/addquestion.component';
import { MyquestionComponent } from '../consulting/myquestion/myquestion.component';
import { NewquestionComponent } from '../consulting/newquestion/newquestion.component';

const routes : Routes=[
  {path:'home', component:HomeComponent},
  {path:'orderhistory', component:OrderhistoryComponent },
  {path:'profile', component:ProfileComponent},
  {path:'store', component:StoreComponent},
  {path:'store/details/:id', component:ProductdetailsComponent},
  {path:'store/details/:id/addtocart/:id', component:AddtocartComponent},
  {path:'mycart', component:MycartComponent},
  {path:'mycart/update/:id', component:UpdateComponent},
  {path:'mycart/order', component:OrderComponent},
  {path:'addtocart/store', component:StoreComponent},
  {path:'mycart/order/orderdetails/:id', component:OrderdetailsComponent},
  {path:'mycart/order/orderdetails/:id/orderpayment', component:OrderpaymentComponent},
  {path:'question/detail/:id', component:DetailsComponent},
  {path:'question', component:QuestionComponent},
  {path:'question/detail/:id/addquestion/:id', component:AddquestionComponent},
  {path:'myQuestion', component:MyquestionComponent},
  {path:'question/detail/:id/newquestion', component:NewquestionComponent},

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
    GetCartDetailsComponent,
    OrderhistoryComponent,
    OrderdetailsComponent
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


