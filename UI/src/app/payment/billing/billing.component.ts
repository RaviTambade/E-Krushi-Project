import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/employee/employee.service';
import { Billing } from '../billing';
import { PaymentService } from '../payment.service';

@Component({
  selector: 'app-billing',
  templateUrl: './billing.component.html',
  styleUrls: ['./billing.component.css']
})
export class BillingComponent implements OnInit{

  bill:Billing={
    Id: 0,
    custId: 0,
    orderId: 0,
    totalAmount:0,
    billDate : new Date()
  }

  custId:number=2;
  orderDetails:any[];
  CustomerName:any|string;
  total:any|number;
  orderId:any;
  constructor(private svc:EmployeeService,private service:PaymentService){
    this.orderDetails=[];
    this.CustomerName=localStorage.getItem("CustomerName");
    this.total=localStorage.getItem("total");
  }
  
  ngOnInit(): void {
    this.svc.getCustomer(this.custId).subscribe((res)=>{
      this.CustomerName=res;
      console.log(this.CustomerName);
      this.CustomerName=(res.firstName+" "+res.lastName);
      console.log(this.CustomerName);
      localStorage.setItem("CustomerName",this.CustomerName);
    }) 
    this.svc.getOrderDetails(this.custId).subscribe((res)=>{
      this.orderDetails=res;
      this.orderId=res.orderId;
      console.log(this.orderDetails);
   }) 
  }
  
  addBill(form:any){
    this.service.addBill(form).subscribe((res)=>{
      this.bill=res;
    })
  }
}
