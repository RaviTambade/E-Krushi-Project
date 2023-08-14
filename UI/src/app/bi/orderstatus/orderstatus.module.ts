import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MonthlyComponent } from './monthly/monthly.component';
import { QuartlyComponent } from './quartly/quartly.component';
import { QuartrlyComponent } from './quartrly/quartrly.component';
import { YearlyComponent } from './yearly/yearly.component';



@NgModule({
  declarations: [
    MonthlyComponent,
    QuartlyComponent,
    QuartrlyComponent,
    YearlyComponent
  ],
  imports: [
    CommonModule
  ]
})
export class OrderstatusModule { }
