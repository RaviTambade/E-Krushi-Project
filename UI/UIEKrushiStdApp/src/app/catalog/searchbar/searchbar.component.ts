import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OrderService } from 'src/app/Services/order-service.service';

@Component({
  selector: 'app-searchbar',
  templateUrl: './searchbar.component.html',
  styleUrls: ['./searchbar.component.css']
})
export class SearchbarComponent  {
   

  searchString:string="";
  constructor(private router:Router){}

   onSearch(){
    console.log(this.searchString)
   this.router.navigate(['catalog/products',this.searchString]) ;
   }
   
  // products:any[]=[{
  //   imageUrl:"/assets/mira.webp" , size :"250 gm" ,price : 100,title : "Admire"
  // },
  // {
  //   imageUrl:"/assets/Rogor.jpeg" , size :"250 gm" ,price : 480,title : "ROGOR"
  // },{
  //   imageUrl:"/assets/UREA.png" , size :"250 gm" ,price : 45,title : "UREA"
  // },
  
  // {
  //   imageUrl:"/assets/antracol.jpeg" , size :"250 gm" ,price : 145,title : "ANTARCOL"
  // },  
  // {
  //   imageUrl:"/assets/Avtar.jpeg" , size :"250 gm" ,price : 115, title : "AVTAR"
  // },  
  // {
  //   imageUrl:"/assets/coragen.jpeg" , size :"250 gm" ,price : 110, title : "CORAGEN"
  // },  
  // {
  //   imageUrl:"/assets/zyme.jpeg" , size :"250 gm" ,price : 450, title : "ZYME"
  // }, 
  // {
  //   imageUrl:"/assets/Melody.jpeg" , size :"250 gm" ,price : 550 ,title : "MELODY"
  // }, 
  // {
  //   imageUrl:"/assets/10-26-26.jpeg" , size :"250 gm" ,price : 400 ,title : "10-26-26"
  // },  
  // {
  //   imageUrl:"/assets/12-32-16.jpeg" , size :"250 gm" ,price : 600,title : "12-32-16"
  // },  
  //  {
  //   imageUrl:"/assets/Goal.jpeg" , size :"250 gm" ,price : 200 ,title : "GOAL"
  // },   


  // {
  //   imageUrl:"/assets/targa-super.png" , size :"250 gm" ,price : 500,title : "TARGA SUPER"
  // }]

  
  // onSelectedProduct(){
  //   console.log(this.selectedProduct);
  //   const sortedProducts=this.products.filter(u=>u.title===this.selectedProduct)
  //   console.log(sortedProducts);
  //   this.products=sortedProducts;

  // }



}
