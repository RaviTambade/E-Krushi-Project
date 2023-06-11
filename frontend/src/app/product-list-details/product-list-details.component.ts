import { Component, OnInit } from '@angular/core';
import { ProducthubService } from '../producthub.service';
import { Product } from '../product';

@Component({
  selector: 'app-product-list-details',
  templateUrl: './product-list-details.component.html',
  styleUrls: ['./product-list-details.component.css']
})
export class ProductListDetailsComponent implements OnInit {

 products:Product[] |any ;
 selectedProduct:any;
  
 constructor(private svc:ProducthubService){ }
  
  ngOnInit():void{
   this.svc.getAllProducts().subscribe((res)=>{
   this.products=res;
   console.log(this.products);
   })
   this.selectedProduct=this.products[0];
}

  onSelectProduct(product:any){
   this.selectedProduct=product;
  }
}
