import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Item } from '../items';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit{

  item:Item={
    quantity:0,
  }
  
  status:boolean |undefined;
    productId:any;
    customerId:any=2;
    cartId:any;
    
    totalAmount:any;

  constructor(private svc:EmployeeService,private router:Router,private route:ActivatedRoute){}
  

 
    ngOnInit(): void { 
    this.productId = this.route.snapshot.paramMap.get('id');
    console.log("ProductId"+this.productId);
     this.svc.getCartId(this.customerId).subscribe((res)=>{
      this.cartId=res;
      console.log("CartId"+this.cartId);
     })
    }

  public onUpdateProduct(form:any){
    console.log(form);
    this.svc.updateQuantity(form).subscribe((res)=>{
    this.status=res;
    console.log(res);
    console.log(this.item);
    if(res){
      window.location.reload();
      alert(" product added Successfully");
    }
    else{
      alert("Error While Adding Record")
    }
    });
  }
}  

  
