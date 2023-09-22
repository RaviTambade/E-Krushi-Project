import { Component, OnChanges, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { AddItem } from 'src/app/Models/addItem';
import { ProductDetail } from 'src/app/Models/productDetail';
import { CartService } from 'src/app/Services/cart.service';
import { CatalogService } from 'src/app/Services/catalog.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css'],
})
export class ProductDetailsComponent  {
  product: ProductDetail = {
    description: '',
    id: 0,
    title: '',
    image: '',
    rating: 0,
    unitPrice: 0,
    size: [],
  };
  selectedSize: string | undefined;
  isProductAlreadyInCart: boolean = false;
  constructor(
    private catlogsvc: CatalogService,
    private route: ActivatedRoute,
    private router: Router,
    private cartsvc: CartService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.product.id = Number(params.get('id'));
      console.log(
        '🚀 ~ this.router.paramMap.subscribe ~ productId:',
        this.product.id
      );
      if (this.product.id != null) {
        this.catlogsvc.getProductDetails(this.product.id).subscribe((res) => {
          this.product = res;
          this.selectedSize = this.product.size[0];
          this.isProductInCart(this.product);
        });
      }
    });
  }



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
      this.isProductInCart(this.product);

  }

  isProductInCart(product: ProductDetail) {
    let customerId = Number(localStorage.getItem('userId'));
    if (this.selectedSize != undefined) {
      let item: AddItem = {
        productId: product.id,
        size: this.selectedSize,
        customerId: customerId,
      };
      console.log(item);
      this.cartsvc.isProductInCart(item).subscribe((res) => {
        console.log(res);
        if (res) {
          this.isProductAlreadyInCart = true;
        }
        else{
          this.isProductAlreadyInCart = false;
          
        }
      });
    }
  }

  onAddToCart(product: ProductDetail) {
    let customerId = Number(localStorage.getItem('userId'));
    console.log('🚀 ~ onAddToCart ~ selectedSize:', this.selectedSize);
    if (this.selectedSize != undefined) {
      let item: AddItem = {
        productId: product.id,
        size: this.selectedSize,
        customerId: customerId,
      };

      this.cartsvc.addItem(item).subscribe((res) => {
        if (res) {
          this.router.navigate(['/customer/shoppingcart']);
        }
      });
    }
  }

  goToCart() {
    this.router.navigate(['/customer/shoppingcart']);
  }
}
