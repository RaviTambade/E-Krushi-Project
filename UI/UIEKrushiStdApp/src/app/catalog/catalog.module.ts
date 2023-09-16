import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from './product/product.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { Route, RouterModule, Routes } from '@angular/router';
import { ShoppingcartComponent } from './shoppingcart/shoppingcart.component';
import { ProductSimilarItemsComponent } from './product-details/product-similar-items/product-similar-items.component';
import { ProductCarouselComponent } from './product-carousel/product-carousel.component';
import { ProductDefaultIconsComponent } from './product-details/product-default-icons/product-default-icons.component';
import { CategoriesComponent } from './categories/categories.component';
import { ProductHomeComponent } from './product-home/product-home.component';
import { SearchbarComponent } from './searchbar/searchbar.component';
import { FormsModule } from '@angular/forms';
import { ProductCategoriesDetailsComponent } from './product-categories-details/product-categories-details.component';

export const catlogRoutes:Routes=[
  {
    path: 'productdetail',
    component: ProductDetailsComponent,
  },
  {
    path: 'categoryproduct/:id',
    component: ProductCategoriesDetailsComponent,
  },
  {
    path: 'products/:input',
    component: ProductComponent,
  },
]
@NgModule({
  declarations: [ProductComponent, ProductDetailsComponent,ShoppingcartComponent, ProductSimilarItemsComponent, ProductCarouselComponent, ProductDefaultIconsComponent, CategoriesComponent, ProductHomeComponent, SearchbarComponent, ProductCategoriesDetailsComponent],

  imports: [
    CommonModule,
    RouterModule,
    FormsModule

  ],
  exports: [
    ProductComponent,
    ShoppingcartComponent,ProductHomeComponent,
    SearchbarComponent
  ]
})
export class CatalogModule {}
