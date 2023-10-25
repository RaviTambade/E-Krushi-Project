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
  @Input() product!: Product;
  selectedSize: string | undefined;
  currentPrice: string | undefined;

  updatePrice() {
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
