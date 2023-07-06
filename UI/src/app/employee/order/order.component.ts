import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { Order } from 'src/app/payment/order';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit{

  orders:any[];
  id:any;
  custId:number=2;
  customer:any;
  customerName:any|string;
  total:any;
  constructor(private svc:EmployeeService,private router:Router,private route:ActivatedRoute){
    this.orders=[];
    this.total=localStorage.getItem("total");
  }

  ngOnInit(): void {
    this.svc.getCustomer(this.custId).subscribe((res)=>{
      this.customer=res;
      console.log(this.customer);
      this.customerName=(res.firstName+" "+res.lastName);
      console.log(this.customerName);
      localStorage.setItem("CustomerName",this.customerName);
    
    }) 

    this.svc.getOrderDetails(this.custId).subscribe((res)=>{
      this.orders=res;

      console.log(this.orders);
    }) 
  }

  onSelectOrder(custId:any){
    console.log(custId);
    this.router.navigate(["./orderdetails",custId],{relativeTo:this.route});
  }
}
