import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { Category } from '../product/category';
import { Product } from '../product/product';
import { ProductService } from '../product/product.service';

@Component({
  selector: 'app-categoryproduct',
  templateUrl: './categoryproduct.component.html',
  styleUrls: ['./categoryproduct.component.css']
})
export class CategoryproductComponent implements OnInit{

  form: FormGroup;
  // matcher = new MyErrorStateMatcher();

  categories: Category[] | undefined;
  products: Product[]| any;
  categoryName:string | any;

  category = new FormControl(null, [Validators.required]);
  product = new FormControl(null, [Validators.required]);

  constructor(private service: ProductService) {
    //fetch all available countries from service
    this.form = new FormGroup({
      category: this.category,
      product:this.product
    });
  }

  ngOnInit(): void {
    this.service.getCategories().subscribe((response)=>{
      this.categories = response;
      console.log(this.categories);
    });
      this.category.valueChanges.subscribe((category) => {
       this.product.reset();
      // this.product.disable();
       if (category) {
         this.service.getProducts(category).subscribe((response)=>{
          this.products=response;
          console.log(this.products);

         })

         this.product.enable();
      }
     });
  }
}



