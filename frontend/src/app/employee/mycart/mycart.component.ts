import { Component, OnInit } from '@angular/core';
import { EmployeeModule } from '../employee.module';
import { EmployeeService } from '../employee.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-mycart',
  templateUrl: './mycart.component.html',
  styleUrls: ['./mycart.component.css']
})
export class MycartComponent implements OnInit{

  carts:any[];
  custId:number=2;
  productId:any;
  
  constructor(private svc :EmployeeService,private router:Router,private route:ActivatedRoute){
    this.carts=[];
  }

  ngOnInit():void {
    this.svc.getCartDetails(this.custId).subscribe((res)=>{
      this.carts=res;
      this.productId=res.productId;
  console.log(this.carts);
   })
  }

  onRemoveProduct(productId:any){
    console.log(this.productId);
    this.svc.removeFromCart(productId).subscribe((res)=>{
      this.productId=res;
      console.log(this.productId);
      if(res){
        window.location.reload();
        alert(" product remove Successfully");
      }
      else{
        alert("Error While deleting Record")
      }
    })
  }
}
