import { Component, OnInit } from '@angular/core';
import { Product } from '@models/product';
import { BannerService } from '@services/banner.service';
import { CatalogService } from '@services/catalog.service';

@Component({
  selector: 'app-product-home',
  templateUrl: './product-home.component.html',
  styleUrls: ['./product-home.component.css'],
})
export class ProductHomeComponent implements OnInit {
  products: Product[] = [];

  bannerCards = [];
  alertmessage:string = "Beware of fraudsters| Get discount on products | Cash On delivery available | 100% original products |Free home delivery."
  
  constructor(
    private catlogsvc: CatalogService,
    private bannerSvc: BannerService
  ) {}
  ngOnInit(): void {
    this.catlogsvc.getProducts().subscribe((res) => {
      this.products = res;
    });

    this.bannerSvc.getAllBanners().subscribe((res) => {
      this.bannerCards = res;
    });
  }
}
