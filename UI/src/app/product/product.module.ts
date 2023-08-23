import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewproductComponent } from './newproduct/newproduct.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ProductsellComponent } from './productsell/productsell.component';
import { ProductdetailsComponent } from './productdetails/productdetails.component';



@NgModule({
  declarations: [
    NewproductComponent,
    ProductsellComponent,
    ProductdetailsComponent
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
