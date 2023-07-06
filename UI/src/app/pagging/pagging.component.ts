import { Component, OnInit } from '@angular/core';
import { Product } from '../product';
import { ProducthubService } from '../producthub.service';

@Component({
  selector: 'app-pagging',
  templateUrl: './pagging.component.html',
  styleUrls: ['./pagging.component.css']
})
export class PaggingComponent implements OnInit{

  startPosition:number=0;
  endPosition:number=1;
  size:number=5;
  products:Product[]; 
  selectedItems :Product[];

  constructor(private svc :ProducthubService ){
    this.selectedItems=[];
    this.products=[];
    this.size= 5;
    this.startPosition=0;
    this.endPosition=this.startPosition+this.size;
    this.selectedItems = this.products.slice(this.startPosition,this.endPosition);
    console.log(this.selectedItems); 
   }

  ngOnInit(): void {
    this.svc.getAllProducts().subscribe((res)=>{
      this.products = res;
      console.log(this.products);
    })
  }

  next(){
       this.startPosition = this.startPosition+this.size;
       this.endPosition = this.startPosition+this.size;
       this.selectedItems = this.products.slice(this.startPosition,this.endPosition);
  }

  previous(){
       this.startPosition = this.startPosition-this.size;
       this.endPosition = this.startPosition+this.size;
       this.selectedItems = this.products.slice(this.startPosition,this.endPosition);
  }
}
