import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BarchartComponent } from './barchart/barchart.component';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [
    BarchartComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule
  ],
  exports: [
    BarchartComponent
  ]
})
export class BIModule { }
