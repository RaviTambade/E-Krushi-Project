import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilterdateComponent } from './filterdate/filterdate.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    FilterdateComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  exports: [
    FilterdateComponent
  ]
})
export class OrderModule { }
