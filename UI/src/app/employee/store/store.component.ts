import { Component, Input, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { Product } from 'src/app/product';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Category } from 'src/app/category';
import { ProducthubService } from 'src/app/producthub.service';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css']
})
export class StoreComponent implements OnInit {
 id:any;
  
 form: FormGroup;
  // matcher = new MyErrorStateMatcher();

  categories: Category[] | undefined;
  products: Product[]| any;
  categoryName:string | any;

  category = new FormControl(null, [Validators.required]);
  product = new FormControl(null, [Validators.required]);

  constructor(private service: ProducthubService,private router:Router,private route:ActivatedRoute) {
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



