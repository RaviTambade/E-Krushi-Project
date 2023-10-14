import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuestionCatagoriesComponent } from './question-catagories/question-catagories.component';
import { ReletedquestionsComponent } from './reletedquestions/reletedquestions.component';
import { CategorywisequestionsComponent } from './categorywisequestions/categorywisequestions.component';
import { RouterModule, Routes } from '@angular/router';

export const consultingRoutes: Routes = [
  {path:'categorywisequestions/:categoryId',component:CategorywisequestionsComponent}
  
]


@NgModule({
  declarations: [
    QuestionCatagoriesComponent,
    ReletedquestionsComponent,
    CategorywisequestionsComponent,
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    QuestionCatagoriesComponent,ReletedquestionsComponent
  ]
})
export class ConsultingModule { }
