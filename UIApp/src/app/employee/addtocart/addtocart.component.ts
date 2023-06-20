import { Component } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { Item } from '../items';

@Component({
  selector: 'app-addtocart',
  templateUrl: './addtocart.component.html',
  styleUrls: ['./addtocart.component.css']
})
export class AddtocartComponent {
  itemDetails:any;

  constructor(private svc:EmployeeService){}


  public addToCart(item:Item){
    this.svc.addToCart(item).subscribe((res)=>{
     this.itemDetails=res;
     console.log(this.itemDetails);
    })
  }

}
