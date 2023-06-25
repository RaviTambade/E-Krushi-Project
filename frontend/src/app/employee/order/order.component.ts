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
  constructor(private svc:EmployeeService,private router:Router,private route:ActivatedRoute){
    this.orders=[];
  }

  ngOnInit(): void {
    this.svc.getAllOrders().subscribe((res)=>{
      this.orders=res;
    }) 
  }

  onSelectOrder(id:any){
    console.log(id);
    this.router.navigate(["./orderdetails",id],{relativeTo:this.route});
  }
}
