import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DailyComponent } from './daily/daily.component';
import { TotalrevenueComponent } from './totalrevenue/totalrevenue.component';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [
    DailyComponent,
    TotalrevenueComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    TotalrevenueComponent
  ]
})
export class ProductsaleModule { }
