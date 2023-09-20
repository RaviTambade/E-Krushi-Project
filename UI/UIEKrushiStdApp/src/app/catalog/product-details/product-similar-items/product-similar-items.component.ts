import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/Models/product';
import { CatalogService } from 'src/app/Services/catalog.service';

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
    console.log(this.productId);

    if (this.productId == undefined) {
      return;
    }

    this.catlogsvc.getSimilarProducts(this.productId).subscribe((res) => {
      this.products = res;
    });
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['productId']
     ) {
      this.catlogsvc.getSimilarProducts(changes['productId'].currentValue).subscribe((res) => {
        this.products = res;
      });
    }
  }
}
