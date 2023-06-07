import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ProducthubService } from '../producthub.service';
import { Category } from '../category';
import { Product } from '../product';

@Component({
  selector: 'app-categoryproduct',
  templateUrl: './categoryproduct.component.html',
  styleUrls: ['./categoryproduct.component.css']
})
export class CategoryproductComponent implements OnInit{

  form: FormGroup;
  // matcher = new MyErrorStateMatcher();

  categories: Category[] | undefined;
  products:Product[]|undefined;
  categoryName:string | any;

  category = new FormControl(null, [Validators.required]);
  product = new FormControl(null, [Validators.required]);

  constructor(private service: ProducthubService) {
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
    
   this.service.getProducts(this.categoryName).subscribe((response)=>{
          this.product=response;
          console.log(this.product);
        })
      
    });
  

  
}
}


