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
    productId:0,
    quantity:0,
    Title:'',
    image:'',
    unitPrice:0
  }

  constructor(private svc:CartService){}
  ngOnInit(): void {
    }


public addToCart(id:number){
    this.svc.addToCart(id).subscribe((res)=>{
    this.item =res;
    console.log(this.item)
    }
    )
  }
}
