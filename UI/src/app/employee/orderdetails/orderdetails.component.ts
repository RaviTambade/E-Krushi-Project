import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-orderdetails',
  templateUrl: './orderdetails.component.html',
  styleUrls: ['./orderdetails.component.css']
})
export class OrderdetailsComponent  implements OnInit{
  orderId:number |any;
  orderDetails:any[];
  custId:any|number;
  customerName:any|string;
  constructor(private svc : EmployeeService,private router:Router,private route:ActivatedRoute){
    this.orderDetails=[]; 
    
    this.customerName=localStorage.getItem("CustomerName");
  }
  
  
  ngOnInit(): void {
    this.custId = this.route.snapshot.paramMap.get('custId');
    this.svc.getOrderDetails(this.custId).subscribe((res)=>{
      this.orderDetails=res;
    }) 
  }

  onClick(){     
     this.router.navigate(["./orderpayment"],{relativeTo:this.route});
  }
}
