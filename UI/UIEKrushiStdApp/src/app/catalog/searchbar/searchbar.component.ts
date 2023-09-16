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
  
}
