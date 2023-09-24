import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerDashboardComponent } from './customer-dashboard/customer-dashboard.component';
import { RouterModule, Routes } from '@angular/router';
import { CustomerOrdersComponent } from './customer-orders/customer-orders.component';
import { CustomerPaymenthistoryComponent } from './customer-paymenthistory/customer-paymenthistory.component';
import { OrderProductDetailsComponent } from './customer-orders/order-product-details/order-product-details.component';
import { OrderDetailsComponent } from './customer-orders/order-details/order-details.component';
import { OrderSummeryComponent } from './customer-orders/order-summery/order-summery.component';
import { PaymentsummeryComponent } from './customer-paymenthistory/paymentsummery/paymentsummery.component';
import { FormsModule } from '@angular/forms';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { ShoppingcartComponent } from './shoppingcart/shoppingcart.component';
import { CartSummaryComponent } from './shoppingcart/cart-summary/cart-summary.component';
import { CustomerQuestionsComponent } from './customer-questions/customer-questions.component';
import { QuestionsComponent } from './customer-questions/questions/questions.component';
import { AddquestionComponent } from './customer-questions/addquestion/addquestion.component';
import { QuestionanswerComponent } from './customer-questions/questionanswer/questionanswer.component';

export const customerRoutes: Routes = [
  { path: 'dashboard', component: CustomerDashboardComponent },
  { path: 'orders', component: CustomerOrdersComponent },
  { path: 'orders/details/:orderid', component: OrderDetailsComponent },
  { path: 'paymentlist', component: CustomerPaymenthistoryComponent },
  { path: 'shoppingcart', component: ShoppingcartComponent },
  {path:'question' , component:CustomerQuestionsComponent,
children:[
  {path:'addquestion' , component:AddquestionComponent},

]},
  {path:'questionHistory' , component:QuestionsComponent},
  {path:'questionAnswer' , component:QuestionanswerComponent},
 
];

@NgModule({
  declarations: [
    CustomerDashboardComponent,
    CustomerOrdersComponent,
    CustomerPaymenthistoryComponent,
    OrderProductDetailsComponent,
    OrderDetailsComponent,
    OrderSummeryComponent,
    ShoppingcartComponent,
    CartSummaryComponent,
    PaymentsummeryComponent,
    CustomerQuestionsComponent,
    QuestionsComponent,
    AddquestionComponent,
    QuestionanswerComponent,
  ],
  imports: [CommonModule, RouterModule, FormsModule, MatSnackBarModule],
})
export class CustomerModule {}
