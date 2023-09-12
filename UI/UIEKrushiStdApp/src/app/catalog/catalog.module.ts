import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from './product/product.component';
import { ShoppingcartComponent } from './shoppingcart/shoppingcart.component';



@NgModule({
  declarations: [
    ProductComponent,
    ShoppingcartComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    ProductComponent,
    ShoppingcartComponent
  ]
})
export class CatalogModule { }
