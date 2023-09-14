import { Component } from '@angular/core';

@Component({
  selector: 'app-customer-paymenthistory',
  templateUrl: './customer-paymenthistory.component.html',
  styleUrls: ['./customer-paymenthistory.component.css']
})
export class CustomerPaymenthistoryComponent {
paymentHistory:any =[
  {paymentId:1,orderId:2,orderdate:'10-02-2022',status:"pending"},
  {paymentId:4,orderId:4,orderdate:'12-06-2020',status:"dilivered"},
  {paymentId:5,orderId:5,orderdate:'16-05-2021',status:"pending"},
  {paymentId:8,orderId:6,orderdate:'04-05-2023',status:"pending"},
]


}
