import { Component, OnInit } from '@angular/core';
import { EmployeeModule } from '../employee.module';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-mycart',
  templateUrl: './mycart.component.html',
  styleUrls: ['./mycart.component.css']
})
export class MycartComponent implements OnInit{

  carts:any[];
  custId:number=2;
  
  
  constructor(private svc :EmployeeService){
    this.carts=[];
  }

  ngOnInit():void {
    this.svc.getCartDetails(this.custId).subscribe((res)=>{
      this.carts=res;
      console.log(this.carts);
   })
  }
}
