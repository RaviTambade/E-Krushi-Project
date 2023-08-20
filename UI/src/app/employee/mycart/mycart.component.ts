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
  userId:number |any;
  productId:any;
  cartId:any;
  id:any;
  totalamount:any;
  unitPrice:any;
  quantity:any;
  cartItemId:any;

  constructor(private svc :EmployeeService,private router:Router,private route:ActivatedRoute){
    this.carts=[];  
    this.userId=localStorage.getItem("userId");
  }

  ngOnInit():void {
    this.svc.getCartDetails(this.userId).subscribe((response)=>{
      this.carts=response;
      console.log(response);
   })
  }

  onRemoveProduct(cartItemId:any){
    console.log(this.cartItemId);
    this.svc.removeFromCart(cartItemId).subscribe((res)=>{
      this.cartItemId=res;
      console.log(this.cartItemId);
      if(res){
        window.location.reload();
        alert(" product remove Successfully");
      }
      else{
        alert("Error While deleting Record")
      }
    })
  }

  onUpdateProduct(id:number): void{
    this.router.navigate(['./update',id],{relativeTo:this.route});
  }


  onClick(): void{
    this.router.navigateByUrl('/billing');
  }

 Total():number{
    let total:any = 0;
    for (let cart of this.carts) {  
          total += cart.unitPrice * cart.quantity;  
          localStorage.setItem("total",total );
    }
    console.log(total);
    return total;
  }
}
