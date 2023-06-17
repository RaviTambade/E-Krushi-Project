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
    quantity:0,
  }
  status:boolean |undefined;
    productId:any;
    customerId:any=2;
    cartId:any;
    unitPrice:any;
    totalAmount:any;

  constructor(private svc:EmployeeService,private router:Router,private route:ActivatedRoute){
    this.unitPrice = localStorage.getItem("price");
    
  }
  
  ngOnInit(): void {
    console.log(this.unitPrice);
    console.log(this.item.quantity);
    
    this.productId = this.route.snapshot.paramMap.get('id');
    console.log("ProductId"+this.productId);
     this.svc.getCartId(this.customerId).subscribe((res)=>{
      this.cartId=res;
      console.log("CartId"+this.cartId);
     })
    }


public addToCart(form:any){
    console.log(form);
    this.totalAmount = (this.item.quantity * this.unitPrice);
    this.svc.addToCart(form).subscribe((res)=>{
    this.status=res;
    console.log(res);
    console.log(this.item);
    if(res){
      window.location.reload();
      alert(" product added Successfully");
    }
    else{
      alert("Error While Inserting Record")
    }
    });
  }
  public removeFromCart(productId:any){
    this.svc.removeFromCart(this.productId).subscribe((res)=>{
      this.productId=res;
      console.log(this.productId);
     })
  }
}
