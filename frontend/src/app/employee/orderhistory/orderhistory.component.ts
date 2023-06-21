import { Component } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-orderhistory',
  templateUrl: './orderhistory.component.html',
  styleUrls: ['./orderhistory.component.css']
})
export class OrderhistoryComponent {

  custId:any=2;
  orders:any[];
  totalAmount:any;
  
  constructor(private svc : EmployeeService,private router:Router,private route:ActivatedRoute ){
    this.orders=[]
    this.totalAmount = localStorage.getItem("total");
  }
  
  ngOnInit(): void {
    this.svc.getOrderDetails(this.custId).subscribe((res)=>{
      this.orders=res;
  }) 
}
}
