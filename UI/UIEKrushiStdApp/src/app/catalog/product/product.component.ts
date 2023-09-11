import { Component } from '@angular/core';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent {
  price :number=100;

  products:any =[{
    imagepath:"/assets/mira.webp" , size :"250 gm" ,price : 100
  },
  {
    imagepath:"/assets/Rogor.jpeg" , size :"250 gm" ,price : 480
  },{
    imagepath:"/assets/UREA.png" , size :"250 gm" ,price : 45
  },
  
  {
    imagepath:"/assets/antracol.jpeg" , size :"250 gm" ,price : 145
  },  
  {
    imagepath:"/assets/Avtar.jpeg" , size :"250 gm" ,price : 115
  },  
  {
    imagepath:"/assets/coragen.jpeg" , size :"250 gm" ,price : 110
  },  
  {
    imagepath:"/assets/zyme.jpeg" , size :"250 gm" ,price : 450
  }, 
  {
    imagepath:"/assets/Melody.jpeg" , size :"250 gm" ,price : 550
  }, 
  {
    imagepath:"/assets/10-26-26.jpeg" , size :"250 gm" ,price : 400
  },  
  {
    imagepath:"/assets/12-32-16.jpeg" , size :"250 gm" ,price : 600
  },  
   {
    imagepath:"/assets/Goal.jpeg" , size :"250 gm" ,price : 200
  },   


  {
    imagepath:"/assets/targa-super.png" , size :"250 gm" ,price : 500
  }]

}
