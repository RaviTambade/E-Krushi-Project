import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit{
  
  custId:any=2;
  orders:any[];
  
  constructor(private svc : EmployeeService){
    this.orders=[]
  }
  
  ngOnInit(): void {
    this.svc.getOrderDetails(this.custId).subscribe((res)=>{
      this.orders=res;
  }) 
}
}
