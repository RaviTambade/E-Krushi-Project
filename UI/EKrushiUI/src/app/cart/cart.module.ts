import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddtocartComponent } from './addtocart/addtocart.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { MycartComponent } from './mycart/mycart.component';



@NgModule({
  declarations: [
    AddtocartComponent,
    MycartComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule
  ],
  exports:[
    AddtocartComponent
  ]
})
export class CartModule { }
