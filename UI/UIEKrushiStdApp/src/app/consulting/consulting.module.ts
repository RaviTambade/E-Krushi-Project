import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuestionCatagoriesComponent } from './question-catagories/question-catagories.component';



@NgModule({
  declarations: [
    QuestionCatagoriesComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    QuestionCatagoriesComponent
  ]
})
export class ConsultingModule { }
