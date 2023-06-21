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
  constructor(private svc : EmployeeService,private router:Router,private route:ActivatedRoute){
    this.orderDetails=[];
    
  }
  
  
  ngOnInit(): void {
    this.orderId = this.route.snapshot.paramMap.get('id');
    this.svc.getDetails(this.orderId).subscribe((res)=>{

      this.orderDetails =res;
    })
   
  }

}
