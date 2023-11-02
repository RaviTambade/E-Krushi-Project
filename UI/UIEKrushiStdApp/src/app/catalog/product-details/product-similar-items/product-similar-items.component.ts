import { Component, ElementRef, Input, OnChanges, Renderer2, SimpleChanges } from '@angular/core';
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
  constructor(private catlogsvc: CatalogService,private el: ElementRef, private renderer: Renderer2) {}

  ngOnInit() {
   

    if (this.productId == undefined) {
      return;
    }

    this.catlogsvc.getSimilarProducts(this.productId).subscribe((res) => {
      this.products = res;
    });
  }

  scrollToTop() {
    window.scrollTo(0, 0);
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['productId']
     ) {
      this.catlogsvc.getSimilarProducts(changes['productId'].currentValue).subscribe((res) => {
        this.products = res;
        this.scrollToTop()
      });
    }
  }
}
