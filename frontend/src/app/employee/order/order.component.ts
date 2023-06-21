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

  constructor(private svc:EmployeeService,private router:Router,private route:ActivatedRoute){
    this.orders=[];
  }

  ngOnInit(): void {
    this.svc.getAllOrders().subscribe((res)=>{
      this.orders=res;
    }) 
  }

  onSelectOrder(id:any){
    this.router.navigate(["./order",id],{relativeTo:this.route});
  }
}
