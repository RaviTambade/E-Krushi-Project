import { Component } from '@angular/core';
import { OrderhubService } from '../orderhub.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent {
  orders:any[];
  id:any;
  userId:any;
  customer:any;
  customerName:any|string;
  total:any;
  constructor(private svc:OrderhubService,private router:Router,private route:ActivatedRoute){
    this.orders=[];
    this.total=localStorage.getItem("total");
    this.userId=localStorage.getItem("userId");
  }

  ngOnInit(): void {
    this.svc.getCustomer(this.userId).subscribe((res)=>{
      this.customer=res;
      console.log(this.customer);
      this.customerName=(res.firstName+" "+res.lastName);
      console.log(this.customerName);
      localStorage.setItem("CustomerName",this.customerName);
    
    }) 

    this.svc.getOrderDetails(this.userId).subscribe((res)=>{
      this.orders=res;

      console.log(this.orders);
    }) 
  }

  onSelectOrder(orderId:any){
    console.log(orderId);
    this.router.navigate(["./orderdetails",orderId],{relativeTo:this.route});
  }
}
