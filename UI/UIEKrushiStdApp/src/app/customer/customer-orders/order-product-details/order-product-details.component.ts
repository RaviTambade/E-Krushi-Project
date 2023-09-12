import { Component, Input } from '@angular/core';
import { OrderedItem } from 'src/app/Models/orderdItem';

@Component({
  selector: 'app-order-product-details',
  templateUrl: './order-product-details.component.html',
  styleUrls: ['./order-product-details.component.css']
})
export class OrderProductDetailsComponent {
 @Input() item!:OrderedItem; 


//  products:any =[{
//   imagepath:"/assets/mira.webp" , size :"250 gm" ,price : 100,name : "Admire",quantity:2
// },
// {
//   imagepath:"/assets/Rogor.jpeg" , size :"250 gm" ,price : 480,name : "ROGOR",quantity:4
// },{
//   imagepath:"/assets/UREA.png" , size :"250 gm" ,price : 45,name : "UREA",quantity:3
// },  
//  {
//   imagepath:"/assets/targa-super.png" , size :"250 gm" ,price : 500,name : "TARGA SUPER",quantity:5
// }]
}
