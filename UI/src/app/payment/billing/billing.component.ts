import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/employee/employee.service';
import { Billing } from '../billing';
import { PaymentService } from '../payment.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-billing',
  templateUrl: './billing.component.html',
  styleUrls: ['./billing.component.css']
})
export class BillingComponent implements OnInit{

  bill:Billing={
    Id: 0,
    custId: 0,
    totalAmount:0,
    billDate : new Date()
  }

  custId:number=2;
  carts:any[];
  CustomerName:any|string;
  totalAmount:any|number;
  orderId:any;

  constructor(private svc:EmployeeService,private service:PaymentService,private router:Router,private route:ActivatedRoute){
    this.carts=[];
    this.CustomerName=localStorage.getItem("CustomerName");
    this.totalAmount=localStorage.getItem("total");
  }
  
  ngOnInit(): void {
    this.svc.getCustomer(this.custId).subscribe((res)=>{
      this.CustomerName=res;
      console.log(this.CustomerName);
      this.CustomerName=(res.firstName+" "+res.lastName);
      console.log(this.CustomerName);
      localStorage.setItem("CustomerName",this.CustomerName);
    }) 
    this.svc.getCartDetails(this.custId).subscribe((res)=>{
      this.carts=res;
      console.log(this.carts);
   }) 
  }
  
  addBill(form:any){
    this.service.addBill(form).subscribe((res)=>{
      this.bill=res;
      if(res){
        window.location.reload();
        alert("  Successfully");
      }
      else{
        alert("Error While deleting Record")
      }

    })
  }

  checkBill(){
    this.router.navigate(['./orderpayment'],{relativeTo:this.route});
  }
}
