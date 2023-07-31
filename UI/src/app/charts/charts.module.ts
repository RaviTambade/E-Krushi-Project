import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BarChartComponent } from './bar-chart/bar-chart.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    BarChartComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,  
  ],
  exports: [
    BarChartComponent
  ]
})
export class ChartsModule { }
