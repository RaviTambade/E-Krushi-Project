import { Component, OnInit } from '@angular/core';
import { CartService } from '../cart.service';
import { Item } from '../items';

@Component({
  selector: 'app-addtocart',
  templateUrl: './addtocart.component.html',
  styleUrls: ['./addtocart.component.css']
})
export class AddtocartComponent implements OnInit{
  items:Item={
    id: 0,
    title: '',
    image: '',
    unitPrice: 0,
    quantity: 0
  }

  cart :any;
  constructor(private svc:CartService){}
  ngOnInit(): void {
    
  }



  public addToCart(item:Item){
    this.svc.addToCart(item).subscribe((res)=>{
    this.cart=res;
    console.log(this.cart)
    }
    )
  }
  
 
}
