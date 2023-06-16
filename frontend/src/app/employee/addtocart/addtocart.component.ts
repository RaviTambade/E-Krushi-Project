import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { Item } from '../items';
import { ActivatedRoute, Route, Router } from '@angular/router';

@Component({
  selector: 'app-addtocart',
  templateUrl: './addtocart.component.html',
  styleUrls: ['./addtocart.component.css']
})
export class AddtocartComponent implements OnInit{
  item:Item={
    productId:0,
    cartId:0,
    quantity:0,
  }
  status:boolean |undefined;
    productId:any;
    customerId:any=2;
    cartId:any;

  constructor(private svc:EmployeeService,private router:Router,private route:ActivatedRoute){}
  
  ngOnInit(): void {
    this.productId = this.route.snapshot.paramMap.get('id');
    console.log("ProductId"+this.productId);
     this.svc.getCartId(this.customerId).subscribe((res)=>{
      this.cartId=res;
      console.log("CartId"+this.cartId);
     })
    }


public addToCart(form:any){
    console.log(form);
    this.svc.addToCart(form).subscribe((res)=>{
    this.status=res;
    console.log(res);
    console.log(this.item);
    if(res){
      window.location.reload();
      alert("Record Inserted Successfully");
    }
    else{
      alert("Error While Inserting Record")
    }
    });
  }
}
