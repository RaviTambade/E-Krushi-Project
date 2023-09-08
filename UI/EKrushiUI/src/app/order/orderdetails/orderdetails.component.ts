import { Component } from '@angular/core';
import { OrderhubService } from '../orderhub.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-orderdetails',
  templateUrl: './orderdetails.component.html',
  styleUrls: ['./orderdetails.component.css']
})
export class OrderdetailsComponent {
 
  orderId:number |any;
  orderDetails:any[];
  userId:any|number;
  customerName:any|string;

  constructor(private svc : OrderhubService,private router:Router,private route:ActivatedRoute){
    this.orderDetails=[]; 
    this.customerName=localStorage.getItem("CustomerName");
    this.userId=localStorage.getItem("userId");
  }
  
  
  ngOnInit(): void {
    this.orderId = this.route.snapshot.paramMap.get('orderId');
    this.svc.getOrderDetails(this.userId).subscribe((res)=>{
      this.orderDetails=res;
    }) 
  }

  onClick(){     
     this.router.navigate(["./orderpayment"],{relativeTo:this.route});
  }
}
