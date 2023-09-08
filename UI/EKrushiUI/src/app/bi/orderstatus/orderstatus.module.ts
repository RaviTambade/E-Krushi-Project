import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MonthlyComponent } from './monthly/monthly.component';
import { QuartrlyComponent } from './quartrly/quartrly.component';
import { MonthlystatusComponent } from './monthlystatus/monthlystatus.component';
import { YearlystatusComponent } from './yearlystatus/yearlystatus.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    MonthlyComponent,
    QuartrlyComponent,
    MonthlystatusComponent,
    YearlystatusComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
    MonthlystatusComponent,
    YearlystatusComponent
  ],

})
export class OrderstatusModule { }
