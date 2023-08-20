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
    userId:any;
    cartId:any;
    unitPrice:any;
    totalAmount:any;
    title:any;
    image:any;
    role:any;

  constructor(private svc:EmployeeService,private router:Router,private route:ActivatedRoute){
    this.unitPrice = localStorage.getItem("price");
    this.title = localStorage.getItem("title");
    this.image = localStorage.getItem("image");
    this.productId=localStorage.getItem("productId");
    this.role=localStorage.getItem("role");
    this.userId=localStorage.getItem("userId");
    }
  
  ngOnInit(): void {
    console.log(this.unitPrice);
    console.log(this.item.quantity);  
    // this.productId = this.route.snapshot.paramMap.get('id');
    console.log("ProductId:"+this.productId);
     this.svc.getCartId(this.userId).subscribe((res)=>{
      this.cartId=res;
      console.log(this.cartId);
      localStorage.setItem("cartId",this.cartId);
      console.log("CartId:"+this.cartId);
     })
  }

public addToCart(form:any){
    console.log(form);
    this.svc.addToCart(form).subscribe((res)=>{
    this.status=res;
    console.log(res);
    console.log(res.cartItemId);
    console.log(res.cartId);
    console.log(res.productId);
    this.router.navigateByUrl('/home');
    // if(res){
    //   window.location.reload();
    //   alert(" product added Successfully");
    // }
    // else{
    //   alert("Error While Adding Record")
    // }
    });
  }

  getRole(): boolean{
    if(this.role==null){
     this.router.navigate(["register"]);
    } 
    return true;
  }
}


