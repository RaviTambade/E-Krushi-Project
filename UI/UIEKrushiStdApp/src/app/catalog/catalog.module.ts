import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from './product/product.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { Route, RouterModule, Routes } from '@angular/router';

export const catlogRoutes:Routes=[
  {
    path: 'productdetail',
    component: ProductDetailsComponent,
  },
]
@NgModule({
  declarations: [ProductComponent, ProductDetailsComponent],
  imports: [
    CommonModule,
    RouterModule

  ],
  exports: [ProductComponent],
})
export class CatalogModule {}
