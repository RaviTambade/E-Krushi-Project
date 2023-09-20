import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductDetail } from 'src/app/Models/productDetail';
import { CatalogService } from 'src/app/Services/catalog.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css'],
})
export class ProductDetailsComponent {
  product: ProductDetail = {
    description: '',
    id: 0,
    title: '',
    image: '',
    rating: 0,
    unitPrice: 0,
    size: [],
  };
  constructor(
    private catlogsvc: CatalogService,
    private router: ActivatedRoute
  ) {}
  ngOnInit(): void {
    this.router.paramMap.subscribe((params) => {
      this.product.id = Number(params.get('id'));
      console.log(
        '🚀 ~ this.router.paramMap.subscribe ~ productId:',
        this.product.id 
      );
      if (this.product.id  != null)
        this.catlogsvc.getProductDetails(this.product.id ).subscribe((res) => {
          this.product = res;
          this.selectedSize = this.product.size[0];
        });
    });
  }

  selectedSize: string | undefined;

  updatePrice(productId: number, size: string) {
    this.selectedSize = size;
    if (this.selectedSize == undefined) {
      return;
    }
    console.log(this.selectedSize);
    this.catlogsvc
      .getProductPriceBySize(productId, this.selectedSize)
      .subscribe((unitprice) => {
        this.product.unitPrice = unitprice;
      });
  }
}
