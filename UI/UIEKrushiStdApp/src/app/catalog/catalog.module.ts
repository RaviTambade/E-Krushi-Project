import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from './product/product.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { Route, RouterModule, Routes } from '@angular/router';
import { ShoppingcartComponent } from './shoppingcart/shoppingcart.component';
import { ProductSimilarItemsComponent } from './product-details/product-similar-items/product-similar-items.component';
import { ProductCarouselComponent } from './product-carousel/product-carousel.component';

export const catlogRoutes:Routes=[
  {
    path: 'productdetail',
    component: ProductDetailsComponent,
  },
]
@NgModule({
  declarations: [ProductComponent, ProductDetailsComponent,ShoppingcartComponent, ProductSimilarItemsComponent, ProductCarouselComponent],

  imports: [
    CommonModule,
    RouterModule

  ],
  exports: [
    ProductComponent,
    ShoppingcartComponent
  ]
})
export class CatalogModule {}
