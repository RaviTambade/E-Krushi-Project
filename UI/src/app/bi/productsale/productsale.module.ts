import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DailyComponent } from './daily/daily.component';
import { TotalrevenueComponent } from './totalrevenue/totalrevenue.component';
import { HttpClientModule } from '@angular/common/http';
import { YearlyComponent } from './yearly/yearly.component';



@NgModule({
  declarations: [
    DailyComponent,
    TotalrevenueComponent,
    YearlyComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    TotalrevenueComponent
  ]
})
export class ProductsaleModule { }
