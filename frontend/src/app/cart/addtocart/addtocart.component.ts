import { Component, OnInit } from '@angular/core';
import { CartService } from '../cart.service';
import { Item } from '../items';

@Component({
  selector: 'app-addtocart',
  templateUrl: './addtocart.component.html',
  styleUrls: ['./addtocart.component.css']
})
export class AddtocartComponent implements OnInit{
  item:Item={
    id:0,
    cartId:0,
    quantity:0,
    title:'',
    image:'',
    unitPrice:0
  }
  status:boolean |undefined;

  constructor(private svc:CartService){}
  ngOnInit(): void {
    }


public addToCart(cartForm:any){
    console.log(cartForm);
    let id = cartForm.cartId;
    console.log(id);
    // this.svc.addToCart().subscribe((res)=>{
    // this.status=res;
    // console.log(this.item)
    // if(res){
    //   window.location.reload();
    //   alert("Record Inserted Successfully");
    // }
    // else{
    //   alert("Error While Inserting Record")
    // }
    // });
  }
}
