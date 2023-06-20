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
    quantity: 0,
    cartid: 0,
    productid: 0,
    cartitemid: 0
  }
  
  status:boolean |undefined;
    productId:any;
    customerId:any=2;
    cartId:any;
    cartItemId:any;
    totalAmount:any;

  constructor(private svc:EmployeeService,private router:Router,private route:ActivatedRoute){   
  }
  
    ngOnInit(): void { 
      this.svc.getCartDetails(this.customerId).subscribe((res)=>{
        this.customerId=res;
        this.cartItemId=res.id;
    console.log(this.customerId);
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

  
