import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MonthlyComponent } from './monthly/monthly.component';
import { QuartrlyComponent } from './quartrly/quartrly.component';
import { YearlyComponent } from './yearly/yearly.component';
import { MonthlystatusComponent } from './monthlystatus/monthlystatus.component';



@NgModule({
  declarations: [
    MonthlyComponent,
    QuartrlyComponent,
    YearlyComponent,
    MonthlystatusComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    MonthlystatusComponent
  ],

})
export class OrderstatusModule { }
