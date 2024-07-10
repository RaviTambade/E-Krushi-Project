import { Component, Input, OnInit } from '@angular/core';
import { TopProduct } from '@models/top-product';

@Component({
  selector: 'store-top-selling-product',
  templateUrl: './top-selling-product.component.html',
  styleUrls: ['./top-selling-product.component.css']
})
export class TopSellingProductComponent implements OnInit {

@Input() product:TopProduct={
  productId: 0,
  quantity: 0,
  totalQuantity: 0,
  percentage:0,
  title: 0,
  imageURL: 0
};
ngOnInit(): void {
  this.product.percentage=Math.round(this.product.percentage);
}
}
