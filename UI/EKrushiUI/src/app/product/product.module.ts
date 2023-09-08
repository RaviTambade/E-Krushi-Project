import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewproductComponent } from './newproduct/newproduct.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ProductsellComponent } from './productsell/productsell.component';
import { ProductdetailsComponent } from './productdetails/productdetails.component';
import { ProductlistComponent } from './productlist/productlist.component';
import { UploadfileComponent } from './uploadfile/uploadfile.component';
import { UpdatequantityComponent } from './updatequantity/updatequantity.component';



@NgModule({
  declarations: [
    NewproductComponent,
    ProductsellComponent,
    ProductdetailsComponent,
    ProductlistComponent,
    UploadfileComponent,
    UpdatequantityComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  exports: [
    NewproductComponent,
    ProductsellComponent,
    ProductlistComponent,
    UploadfileComponent,
    UpdatequantityComponent
  ]
})
export class ProductModule { }
