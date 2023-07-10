import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewproductComponent } from './newproduct/newproduct.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [
    NewproductComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule
  ],
  exports: [
    NewproductComponent
  ]
})
export class ProductModule { }
