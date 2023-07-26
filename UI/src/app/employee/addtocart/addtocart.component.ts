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
    cartId: 0,
    quantity: 0,
    productId: 0,
    cartItemId: 0
  }
  
  status:boolean |undefined;
    productId:any;
    customerId:any=2;
    cartId:any;
    unitPrice:any;
    totalAmount:any;
    title:any;
    image:any;

  constructor(private svc:EmployeeService,private router:Router,private route:ActivatedRoute){
    this.unitPrice = localStorage.getItem("price");
    this.title = localStorage.getItem("title");
    this.image = localStorage.getItem("image");
    this.productId=localStorage.getItem("productId");
    }
  
  ngOnInit(): void {
    console.log(this.unitPrice);
    console.log(this.item.quantity);  
    // this.productId = this.route.snapshot.paramMap.get('id');
    console.log("ProductId:"+this.productId);
     this.svc.getCartId(this.customerId).subscribe((res)=>{
      this.cartId=res;
      localStorage.setItem("cartId",this.cartId);
      console.log("CartId:"+this.cartId);
     })
  }

public addToCart(form:any){
    console.log(form);
    this.svc.addToCart(form).subscribe((res)=>{
    this.status=res;
    console.log(res);
    console.log(this.item);
    this.router.navigate(['/home']);
    // if(res){
    //   window.location.reload();
    //   alert(" product added Successfully");
    // }
    // else{
    //   alert("Error While Adding Record")
    // }
    });
  }


}


