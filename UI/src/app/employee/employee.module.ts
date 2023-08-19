import { NgModule } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { StoreComponent } from './store/store.component';
import { ProfileComponent } from './profile/profile.component';
import { OrderComponent } from './order/order.component';
import { RoutingComponent } from './routing/routing.component';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { ProductdetailsComponent } from './productdetails/productdetails.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AddtocartComponent } from '../employee/addtocart/addtocart.component';
import { MycartComponent } from './mycart/mycart.component';
import { UpdateComponent } from './update/update.component';
import { BillingComponent } from '../payment/billing/billing.component';
import { OrderpaymentComponent } from '../payment/orderpayment/orderpayment.component';
import { OrderhistoryComponent } from './orderhistory/orderhistory.component';
import { OrderdetailsComponent } from './orderdetails/orderdetails.component';
import { QuestionComponent } from '../consulting/question/question.component';
import { DetailsComponent } from '../consulting/details/details.component';
import { AddquestionComponent } from '../consulting/addquestion/addquestion.component';
import { MyquestionComponent } from '../consulting/myquestion/myquestion.component';
import { NewquestionComponent } from '../consulting/newquestion/newquestion.component';
import { QuestioncategoryComponent } from '../consulting/questioncategory/questioncategory.component';
import { DebitcardComponent } from '../payment/debitcard/debitcard.component';
import { QuestionanswerComponent } from '../consulting/questionanswer/questionanswer.component';
import { UploadfileComponent } from './uploadfile/uploadfile.component';
import { LoginComponent } from '../authentication/login/login.component';
import { RegisterComponent } from '../authentication/register/register.component';
import { CustomerproductsaleComponent } from './customerproductsale/customerproductsale.component';


const routes : Routes=[
  {path:'register', component:RegisterComponent},
  {path:'home', component:HomeComponent},
  {path:'login', component:LoginComponent},
  {path:'orderhistory', component:OrderhistoryComponent },
  {path:'profile', component:ProfileComponent},
  {path:'store', component:StoreComponent},
  {path:'home/details/:id', component:ProductdetailsComponent},
  {path:'home/details/:id/addtocart/:id', component:AddtocartComponent},
  {path:'mycart', component:MycartComponent},
  {path:'mycart/update/:id', component:UpdateComponent},
  {path:'billing', component:BillingComponent},
  {path:'orderpayment', component:OrderpaymentComponent},
  {path:'addtocart', component:AddtocartComponent},
  {path:'mycart/order/orderdetails/:custId', component:OrderdetailsComponent},
  {path:'mycart/order/orderdetails/:id/orderpayment', component:OrderpaymentComponent},
  {path:'questioncategory/newquestion', component:NewquestionComponent},
  {path:'questioncategory', component:QuestioncategoryComponent},
  {path:'questioncategory/details/:id/addquestion/:id', component:AddquestionComponent},
  {path:'myQuestion', component:MyquestionComponent},
  {path:'newquestion', component:NewquestionComponent},
  {path:'store/details/:id', component:ProductdetailsComponent},
  {path:'store/details/:id/addtocart/:id', component:AddtocartComponent},
  {path:'questioncategory/details/:id', component:DetailsComponent},
  {path:'debitcard', component:DebitcardComponent},
  {path:'myQuestion/answers/:questionId', component:QuestionanswerComponent},
  {path:'Employee/routing', component:RoutingComponent},
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
    OrderhistoryComponent,
    OrderdetailsComponent,
    UploadfileComponent,
    CustomerproductsaleComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RoutingComponent,
    StoreComponent,
    OrderComponent,
    CustomerproductsaleComponent,
    UploadfileComponent
  ]
})

export class EmployeeModule { }


