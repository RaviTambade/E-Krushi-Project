import { Component, OnInit } from '@angular/core';

import { Product } from '../product/product';
import { ProductService } from '../product/product.service';

@Component({
  selector: 'app-product-list-details',
  templateUrl: './product-list-details.component.html',
  styleUrls: ['./product-list-details.component.css']
})
export class ProductListDetailsComponent implements OnInit {

 products:Product[] |any ;
 selectedProduct:any;
  
 constructor(private svc:ProductService){ }
  
  ngOnInit():void{
   this.svc.getAllProducts().subscribe((res)=>{
   this.products=res;
   this.selectedProduct=this.products[0];
   console.log(this.products);
   })
}

  onSelectProduct(product:any){
    this.svc.getById(product).subscribe((res)=>{
      this.selectedProduct=res;
    })
  }
}
