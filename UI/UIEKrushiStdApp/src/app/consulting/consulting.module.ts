import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuestionCatagoriesComponent } from './question-catagories/question-catagories.component';
import { ReletedquestionsComponent } from './reletedquestions/reletedquestions.component';



@NgModule({
  declarations: [
    QuestionCatagoriesComponent,
    ReletedquestionsComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    QuestionCatagoriesComponent,ReletedquestionsComponent
  ]
})
export class ConsultingModule { }
