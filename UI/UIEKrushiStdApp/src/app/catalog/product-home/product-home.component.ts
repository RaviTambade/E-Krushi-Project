import { Component, OnInit } from '@angular/core';
import { Product } from '@models/product';
import { CatalogService } from '@services/catalog.service';


@Component({
  selector: 'app-product-home',
  templateUrl: './product-home.component.html',
  styleUrls: ['./product-home.component.css'],
})
export class ProductHomeComponent implements OnInit {
  products: Product[] = [];
  constructor(private catlogsvc: CatalogService) {}
  ngOnInit(): void {
    this.catlogsvc.getProducts().subscribe((res) => {
      this.products = res;
    });
  }
}
