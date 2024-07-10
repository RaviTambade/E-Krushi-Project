import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SessionStorageKeys } from '@enums/session-storage-keys';
import { ProductDescription } from '@models/ProductDescription';
import { CartItem } from '@models/cart-item';
import { CartService } from '@services/cart.service';
import { CatalogService } from '@services/catalog.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css'],
})
export class ProductDetailsComponent {
 
  product: ProductDescription = {
    description: '',
    id: 0,
    title: '',
    image: '',
    rating: 0,
    productDetails: [],
  };
  selectedSize: string | undefined;
  currentPrice: number | undefined;
  isProductAlreadyInCart: boolean = false;
  productDetailId: number | undefined;
  constructor(
    private catlogsvc: CatalogService,
    private route: ActivatedRoute,
    private router: Router,
    private cartsvc: CartService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.product.id = Number(params.get('id'));

      if (this.product.id != null) {
        this.catlogsvc.getProductDetails(this.product.id).subscribe((res) => {
          this.product = res;

          this.selectedSize = this.product.productDetails[0].size;
          this.currentPrice = Number(this.product.productDetails[0].unitPrice);
          this.productDetailId = Number(
            this.product.productDetails[0].productDetailId
          );
          this.isProductInCart(this.productDetailId);
        });
      }
    });
  }

  onUpdatePrice(size: string) {
    this.selectedSize = size;
    if (this.selectedSize == undefined) {
      return;
    }
    this.currentPrice = Number(
      this.product.productDetails.find((pd) => pd.size == this.selectedSize)
        ?.unitPrice
    );

    this.productDetailId = Number(
      this.product.productDetails.find((pd) => pd.size == this.selectedSize)
        ?.productDetailId
    );

    this.isProductInCart(this.productDetailId);
  }

  isProductInCart(productDetailsId: number) {
    this.cartsvc.isProductInCart(productDetailsId).subscribe((res) => {
      if (res) {
        this.isProductAlreadyInCart = true;
      } else {
        this.isProductAlreadyInCart = false;
      }
    });
  }

  onAddToCart() {
    if (this.selectedSize != undefined) {
      const item: CartItem = {
        productDetailsId: Number(this.productDetailId),
        productId: this.product.id,
        title: this.product.title,
        size: this.selectedSize,
        image: this.product.image,
        quantity: 1,
        unitPrice: Number(this.currentPrice),
      };
      this.cartsvc.addItem(item).subscribe((res) => {
        if (res) {
          this.router.navigate(['/crm/shoppingcart']);
        }
      });
    }
  }

  onClickBuyNow(product: ProductDescription) {
    if (this.selectedSize == undefined) {
      return;
    }
    let item: CartItem = {
      productId: product.id,
      title: product.title,
      size: this.selectedSize,
      image: product.image,
      quantity: 1,
      unitPrice: Number(this.currentPrice),
      productDetailsId: Number(this.productDetailId),
    };
    this.cartsvc.addItem(item).subscribe((res) => {
      if (res) {
        sessionStorage.setItem(SessionStorageKeys.isBuyNow, 'true');
        this.router.navigate(['/orderprocessing']);
      }
    });
  }
}
