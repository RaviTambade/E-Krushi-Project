import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent {
  price :number=100;
  constructor(private router:Router){}
  products:any =[{
    imagepath:"/assets/mira.webp" , size :"250 gm" ,price : 100,name : "Admire"
  },
  {
    imagepath:"/assets/Rogor.jpeg" , size :"250 gm" ,price : 480,name : "ROGOR"
  },{
    imagepath:"/assets/UREA.png" , size :"250 gm" ,price : 45,name : "UREA"
  },
  
  {
    imagepath:"/assets/antracol.jpeg" , size :"250 gm" ,price : 145,name : "ANTARCOL"
  },  
  {
    imagepath:"/assets/Avtar.jpeg" , size :"250 gm" ,price : 115, name : "AVTAR"
  },  
  {
    imagepath:"/assets/coragen.jpeg" , size :"250 gm" ,price : 110, name : "CORAGEN"
  },  
  {
    imagepath:"/assets/zyme.jpeg" , size :"250 gm" ,price : 450, name : "ZYME"
  }, 
  {
    imagepath:"/assets/Melody.jpeg" , size :"250 gm" ,price : 550 ,name : "MELODY"
  }, 
  {
    imagepath:"/assets/10-26-26.jpeg" , size :"250 gm" ,price : 400 ,name : "10-26-26"
  },  
  {
    imagepath:"/assets/12-32-16.jpeg" , size :"250 gm" ,price : 600,name : "12-32-16"
  },  
   {
    imagepath:"/assets/Goal.jpeg" , size :"250 gm" ,price : 200 ,name : "GOAL"
  },   


  {
    imagepath:"/assets/targa-super.png" , size :"250 gm" ,price : 500,name : "TARGA SUPER"
  }]

  onClickDetails(){
    this.router.navigate(['/catalog/productdetail']);
  }
}
