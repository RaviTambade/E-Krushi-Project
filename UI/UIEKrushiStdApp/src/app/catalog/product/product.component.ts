import { Component, Input, OnInit } from '@angular/core';
import { Product } from '@models/product';


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit {
  @Input() product!: Product;
  selectedSize: string | undefined;
  currentPrice: string | undefined;

  onUpdatePrice() {
    if (this.selectedSize == undefined) {
      return;
    }
    this.currentPrice = this.product.productDetails.find(
      (pd) => pd.size == this.selectedSize
    )?.unitPrice;
  }

  ngOnInit(): void {
    this.selectedSize = this.product.productDetails[0].size;
    this.currentPrice = this.product.productDetails[0].unitPrice;
  }
}
