import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewproductComponent } from './newproduct/newproduct.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ProductsellComponent } from './productsell/productsell.component';



@NgModule({
  declarations: [
    NewproductComponent,
    ProductsellComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule
  ],
  exports: [
    NewproductComponent,
    ProductsellComponent
  ]
})
export class ProductModule { }
