import { NgModule } from '@angular/core';

import { RoutingComponent } from './routing/routing.component';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { BillingComponent } from '../payment/billing/billing.component';
import { OrderpaymentComponent } from '../payment/orderpayment/orderpayment.component';
import { QuestionComponent } from '../consulting/question/question.component';
import { DetailsComponent } from '../consulting/details/details.component';
import { AddquestionComponent } from '../consulting/addquestion/addquestion.component';
import { MyquestionComponent } from '../consulting/myquestion/myquestion.component';
import { NewquestionComponent } from '../consulting/newquestion/newquestion.component';
import { QuestioncategoryComponent } from '../consulting/questioncategory/questioncategory.component';
import { DebitcardComponent } from '../payment/debitcard/debitcard.component';
import { QuestionanswerComponent } from '../consulting/questionanswer/questionanswer.component';
import { LoginComponent } from '../authentication/login/login.component';
import { RegisterComponent } from '../authentication/register/register.component';
import { AddtocartComponent } from '../cart/addtocart/addtocart.component';
import { MycartComponent } from '../cart/mycart/mycart.component';
import { OrderdetailsComponent } from '../order/orderdetails/orderdetails.component';
import { ProductdetailsComponent } from '../product/productdetails/productdetails.component';
import { OrderhistoryComponent } from '../order/orderhistory/orderhistory.component';
import { HomeComponent } from '../default/home/home.component';
import { LogoutComponent } from '../authentication/logout/logout.component';

import { ProductlistComponent } from '../product/productlist/productlist.component';
import { UserprofileComponent } from '../users/userprofile/userprofile.component';
import { EdituserComponent } from '../users/edituser/edituser.component';
import { ResetpasswordComponent } from '../users/resetpassword/resetpassword.component';
import { UpdatequantityComponent } from '../product/updatequantity/updatequantity.component';


const routes : Routes=[ 
  {path:'', component:HomeComponent},
  {path:'register', component:RegisterComponent},
  {path:'home', component:HomeComponent},
  {path:'login', component:LoginComponent},
  {path:'orderhistory', component:OrderhistoryComponent },
  {path:'store', component:ProductlistComponent},
  {path:'home/details/:id', component:ProductdetailsComponent},
  {path:'home/details/:id/addtocart/:id', component:AddtocartComponent},
  {path:'mycart', component:MycartComponent},
  {path:'mycart/update/:id', component:UpdatequantityComponent},
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
  {path:'orderdetails/:userId', component:OrderdetailsComponent},
  {path:'logout', component:LogoutComponent},
  {path:'profile', component:UserprofileComponent},
  {path:'profile/editprofile', component:EdituserComponent},
  {path:'profile/resetpassword', component:ResetpasswordComponent}
]

@NgModule({
  declarations: [
    HomeComponent,
    RoutingComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RoutingComponent
  ]
})

export class EmployeeModule { }


