import { Component } from '@angular/core';
import { OrderhubService } from '../orderhub.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-orderhistory',
  templateUrl: './orderhistory.component.html',
  styleUrls: ['./orderhistory.component.css']
})
export class OrderhistoryComponent {


  userId:any;
  orders:any[];
  totalAmount:any;
  cartItemId:any;
  
  constructor(private svc : OrderhubService,private router:Router,private route:ActivatedRoute ){
    this.orders=[];
    this.userId=localStorage.getItem("userId");
    this.totalAmount = localStorage.getItem("total");
  }
  
  ngOnInit(): void {
    this.svc.getOrderDetails(this.userId).subscribe((res)=>{
      this.orders=res;
      console.log(this.cartItemId);
  }) 
}
}
