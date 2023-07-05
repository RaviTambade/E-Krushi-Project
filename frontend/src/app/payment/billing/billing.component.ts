import { Component, OnInit } from '@angular/core';
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
  title:any;
  image:any;
  unitPrice:any;
  custId:number=2;
  totalAmount:any;

  constructor(private svc:PaymentService){
    this.title = localStorage.getItem("title");
    this.image = localStorage.getItem("image");
    this.unitPrice = localStorage.getItem("price");
    this.totalAmount= localStorage.getItem("total");
    this.totalAmount= localStorage.getItem("quantity");
  }
  
  ngOnInit(): void {
  }
  
  addBill(form:any){
    this.svc.addBill(form).subscribe((res)=>{
      this.bill=res;
    })
  }
}
