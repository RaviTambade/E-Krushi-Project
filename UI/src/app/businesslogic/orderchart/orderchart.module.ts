import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DailyComponent } from './daily/daily.component';
import { WeeklyComponent } from './weekly/weekly.component';
import { MonthlyComponent } from './monthly/monthly.component';
import { YearlyComponent } from './yearly/yearly.component';
import { QuarterlyComponent } from './quarterly/quarterly.component';



@NgModule({
  declarations: [
    DailyComponent,
    WeeklyComponent,
    MonthlyComponent,
    YearlyComponent,
    QuarterlyComponent
  ],
  imports: [
    CommonModule
  ]
})
export class OrderchartModule { }
