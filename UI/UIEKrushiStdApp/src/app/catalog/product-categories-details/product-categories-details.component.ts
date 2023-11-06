import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '@models/product';
import { CatalogService } from '@services/catalog.service';

@Component({
  selector: 'app-product-categories-details',
  templateUrl: './product-categories-details.component.html',
  styleUrls: ['./product-categories-details.component.css']
})
export class ProductCategoriesDetailsComponent {
  products: Product[] = [];
  constructor(private catlogsvc: CatalogService,private router:ActivatedRoute) {}
  ngOnInit(): void {
    this.router.paramMap.subscribe((params)=>{
      let categoryId=params.get('id');
      if(categoryId!=null)
      this.catlogsvc.getProductsByCategory(categoryId).subscribe((res) => {
        this.products = res;
      });
    });
   
  }
}
