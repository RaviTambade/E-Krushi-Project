import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/Models/product';
import { CatalogService } from 'src/app/Services/catalog.service';

@Component({
  selector: 'app-product-similar-items',
  templateUrl: './product-similar-items.component.html',
  styleUrls: ['./product-similar-items.component.css'],
})
export class ProductSimilarItemsComponent {
  @Input() productId: number | undefined;
  products: Product[] = [];
  constructor(private catlogsvc: CatalogService) {}

  ngOnInit() {
    console.log(this.productId)
    if (this.productId == undefined) {
      return;
    }

    this.catlogsvc.getSimilarProducts(this.productId).subscribe((res) => {
      this.products = res;
    });
  }

  
}
