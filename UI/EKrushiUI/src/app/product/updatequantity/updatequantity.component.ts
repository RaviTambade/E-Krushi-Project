import { Component } from '@angular/core';
import { ProductService } from '../product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Item } from 'src/app/cart/items';

@Component({
  selector: 'app-updatequantity',
  templateUrl: './updatequantity.component.html',
  styleUrls: ['./updatequantity.component.css']
})
export class UpdatequantityComponent {

  item:Item={
    quantity: 0,
    cartId: 0,
    productId: 0,
    cartItemId: 0
  }
  
  status:boolean |undefined;
    productId:any;
    userId:any;
    cartId:any;
    cartItemId:any;
    totalAmount:any;

  constructor(private svc:ProductService,private router:Router,private route:ActivatedRoute){ 
    this.userId=localStorage.getItem("userId");  
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
