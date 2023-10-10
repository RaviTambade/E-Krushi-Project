import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { orderSp } from 'src/app/Models/orderSp';
import { BIService } from 'src/app/Services/bi.service';

@Component({
  selector: 'app-orderscount',
  templateUrl: './orderscount.component.html',
  styleUrls: ['./orderscount.component.css']
})
export class OrderscountComponent implements OnInit{
  currentDate: string = new Date().toISOString().slice(0,10);
  storeid:number=1;

  order:orderSp|undefined;
  constructor(private svc:BIService){ 
  }
  ngOnInit(): void {
    console.log(this.currentDate);
    this.svc.getOrdersFromStoreProcedure(this.currentDate,this.storeid).subscribe((res)=>{
      console.log(res);
     
        this.order=res;      
    })
  }


   
  
}
