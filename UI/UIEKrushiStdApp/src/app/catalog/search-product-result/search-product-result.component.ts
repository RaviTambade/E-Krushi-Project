import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/Models/product';
import { CatalogService } from 'src/app/Services/catalog.service';

@Component({
  selector: 'app-search-product-result',
  templateUrl: './search-product-result.component.html',
  styleUrls: ['./search-product-result.component.css']
})
export class SearchProductResultComponent {
  products: Product[] = [];
  constructor(private catlogsvc: CatalogService,private router:ActivatedRoute) {}
  ngOnInit(): void {
    this.router.paramMap.subscribe((params)=>{
      let searchString=params.get('input');
      if(searchString!=null)
      this.catlogsvc.getSearchedProducts(searchString).subscribe((res) => {
        this.products = res;
      });
    });
   
  }
}
