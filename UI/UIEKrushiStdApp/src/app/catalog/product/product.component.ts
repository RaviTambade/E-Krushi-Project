import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/Models/product';
import { CatalogService } from 'src/app/Services/catalog.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit {
  // searchString: string | null = null;

  @Input() product!: Product;
  selectedSize: string | undefined;
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private catalogsvc: CatalogService
  ) {}

  updatePrice(productId: number) {
    if (this.selectedSize == undefined) {
      return;
    }
    console.log(this.selectedSize);
    this.catalogsvc
      .getProductPriceBySize(productId, this.selectedSize)
      .subscribe((unitprice) => {
        this.product.unitPrice = unitprice;
      });
  }

  ngOnInit(): void {
    this.selectedSize = this.product.size[0];

    // this.route.paramMap.subscribe((params) => {
    //   this.searchString = params.get('input');
    //   if (this.searchString != null) {
    //     this.products = this.filterProducts(this.searchString);
    //   }
    // });
  }

  // filterProducts(searchString: string) {
  //   var products = this.products.filter((p) => p.title == searchString);
  //   return products;
  // }
}
