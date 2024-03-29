import { Component, OnInit } from '@angular/core';
import { Product } from '../product/product';
import { ProductService } from '../product/product.service';

@Component({
  selector: 'app-productgrid',
  templateUrl: './productgrid.component.html',
  styleUrls: ['./productgrid.component.css']
})
export class ProductgridComponent implements OnInit {
products:Product[] |undefined
id:number |any;
product:any;

  constructor(private svc:ProductService){}

  ngOnInit(): void {
    this.svc.getAllProducts().subscribe((res)=>{
      this.products=res;
      console.log(this.products);
    })
  }
  getById(id:number){
    this.svc.getById(id).subscribe((res)=>{
      this.product=res;
    })
  }

  Delete(id:number){
    this.svc.Delete(id).subscribe((res)=>{

      // this.products = this.products.filter(this.product => this.product.id !== id)
      this.product=res
    })
  }

  
  
}
