import { NgModule } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { StoreComponent } from './store/store.component';
import { RoutingComponent } from './routing/routing.component';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { ProductdetailsComponent } from './productdetails/productdetails.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { UpdateComponent } from './update/update.component';
import { BillingComponent } from '../payment/billing/billing.component';
import { OrderpaymentComponent } from '../payment/orderpayment/orderpayment.component';
import { OrderhistoryComponent } from './orderhistory/orderhistory.component';
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
import { DefaultComponent } from './default/default.component';
import { AddtocartComponent } from '../cart/addtocart/addtocart.component';
import { MycartComponent } from '../cart/mycart/mycart.component';
import { OrderdetailsComponent } from '../order/orderdetails/orderdetails.component';



const routes : Routes=[ 
  {path:'', component:DefaultComponent},
  {path:'register', component:RegisterComponent},
  {path:'home', component:HomeComponent},
  {path:'login', component:LoginComponent},
  {path:'orderhistory', component:OrderhistoryComponent },
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
  {path:'orderdetails/:userId', component:OrderdetailsComponent}
]

@NgModule({
  declarations: [
    HomeComponent,
    StoreComponent,
    RoutingComponent,
    ProductdetailsComponent,
    UpdateComponent,
    OrderhistoryComponent,
    UploadfileComponent,
    CustomerproductsaleComponent,
    DefaultComponent
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
    CustomerproductsaleComponent,
    UploadfileComponent,
    DefaultComponent
  ]
})

export class EmployeeModule { }


