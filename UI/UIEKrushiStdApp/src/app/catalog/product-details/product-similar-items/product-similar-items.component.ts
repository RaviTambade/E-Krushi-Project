import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Product } from '@models/product';
import { CatalogService } from '@services/catalog.service';

@Component({
  selector: 'app-product-similar-items',
  templateUrl: './product-similar-items.component.html',
  styleUrls: ['./product-similar-items.component.css'],
})
export class ProductSimilarItemsComponent implements OnChanges {
  @Input() productId: number | undefined;
  products: Product[] = [];
  constructor(private catlogsvc: CatalogService) {}

  ngOnInit() {
    if (this.productId == undefined) {
      return;
    }

    this.catlogsvc.getSimilarProducts(this.productId).subscribe((res) => {
      this.products = res;
    });
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['productId']) {
      this.catlogsvc
        .getSimilarProducts(changes['productId'].currentValue)
        .subscribe((res) => {
          this.products = res;
          window.scrollTo(0, 0);
        });
    }
  }
}
