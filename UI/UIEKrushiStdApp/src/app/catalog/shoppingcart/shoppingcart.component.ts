import { Component } from '@angular/core';
import { ProductComponent } from '../product/product.component';

@Component({
  selector: 'app-shoppingcart',
  templateUrl: './shoppingcart.component.html',
  styleUrls: ['./shoppingcart.component.css']
})
export class ShoppingcartComponent{

  price :number=100;

  products:any =[{
    imagepath:"/assets/mira.webp" , size :"250 gm" ,price : 100,name : "Admire",quantity:2
  },
  {
    imagepath:"/assets/Rogor.jpeg" , size :"250 gm" ,price : 480,name : "ROGOR",quantity:4
  },{
    imagepath:"/assets/UREA.png" , size :"250 gm" ,price : 45,name : "UREA",quantity:3
  },  
   {
    imagepath:"/assets/targa-super.png" , size :"250 gm" ,price : 500,name : "TARGA SUPER",quantity:5
  }]


}
