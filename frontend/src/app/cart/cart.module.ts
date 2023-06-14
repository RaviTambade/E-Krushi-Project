import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddtocartComponent } from './addtocart/addtocart.component';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [
    AddtocartComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule
  ],
  exports:[
    CartModule
  ]
})
export class CartModule { }
