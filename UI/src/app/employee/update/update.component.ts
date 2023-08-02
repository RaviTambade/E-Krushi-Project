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
    cartId: 0,
    productId: 0,
    cartItemId: 0
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

      this.cartItemId = this.route.snapshot.paramMap.get('id');
      console.log(this.cartItemId);
      this.svc.get(this.cartItemId).subscribe((res)=>{
        this.item=res;
      console.log(res);
    
     })
    }

  public onUpdateProduct(form:any){
    console.log(form);
    this.svc.updateQuantity(form).subscribe((res)=>{
    this.status=res;
    console.log(res);
    console.log(this.item);
    this.router.navigate(['/mycart']);
   
    });
  
    
   
  } 

  
}  

  