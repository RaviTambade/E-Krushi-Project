import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from './product/product.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { Route, RouterModule, Routes } from '@angular/router';
import { ProductSimilarItemsComponent } from './product-details/product-similar-items/product-similar-items.component';
import { ProductCarouselComponent } from './product-carousel/product-carousel.component';
import { ProductDefaultIconsComponent } from './product-details/product-default-icons/product-default-icons.component';
import { CategoriesComponent } from './categories/categories.component';
import { ProductHomeComponent } from './product-home/product-home.component';
import { FormsModule } from '@angular/forms';
import { ProductCategoriesDetailsComponent } from './product-categories-details/product-categories-details.component';
import { SearchProductResultComponent } from './search-product-result/search-product-result.component';
import { AlertComponent } from './alert/alert.component';

export const catlogRoutes: Routes = [
  {
    path: 'productdetail/:id',
    component: ProductDetailsComponent,
  },
  {
    path: 'categoryproduct/:id',
    component: ProductCategoriesDetailsComponent,
  },
  {
    path: 'products/:input',
    component: SearchProductResultComponent,
  },
];
@NgModule({
  declarations: [
    ProductComponent,
    ProductDetailsComponent,
    ProductSimilarItemsComponent,
    ProductCarouselComponent,
    ProductDefaultIconsComponent,
    CategoriesComponent,
    ProductHomeComponent,
    ProductCategoriesDetailsComponent,
    SearchProductResultComponent,
    AlertComponent,
  ],

  imports: [CommonModule, RouterModule, FormsModule],
  exports: [ ProductHomeComponent],
})
export class CatalogModule {}

