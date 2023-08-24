import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Category } from '../category';
import { Product } from '../product';

import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-productlist',
  templateUrl: './productlist.component.html',
  styleUrls: ['./productlist.component.css']
})
export class ProductlistComponent {
 
  id:any;
  
 form: FormGroup;
  // matcher = new MyErrorStateMatcher();

  categories: Category[] | undefined;
  products: Product[]| any;
  categoryName:string | any;

  category = new FormControl(null, [Validators.required]);
  product = new FormControl(null, [Validators.required]);

  constructor(private service: ProductService,private router:Router,private route:ActivatedRoute) {
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
          localStorage.setItem("category",category);
          console.log(this.products);
         })
         this.product.enable();
        }
    });
  } 
  
  onSelectProduct(id:any){
    console.log(id);
    this.router.navigate(["details",id],{relativeTo:this.route});
  }
}
