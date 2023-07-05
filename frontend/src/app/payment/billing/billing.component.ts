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
    productId: 0,
    quantity: 0,
    billDate : new Date()
  }

  carts:any[];
  custId:number=2;
  productId:any;
  unitPrice:any;
  quantity:any

  constructor(private svc:PaymentService,private service:EmployeeService){
    this.carts=[];
  }
  
  ngOnInit(): void {
    this.service.getCartDetails(this.custId).subscribe((res)=>{
      this.carts=res;
      this.productId=res.productId;
      this.unitPrice=res.unitPrice;
      this.quantity=res.quantity;
    console.log(this.carts);
   })
   
  }
  
  addBill(form:any){
    this.svc.addBill(form).subscribe((res)=>{
      this.bill=res;
    })
  }
}
