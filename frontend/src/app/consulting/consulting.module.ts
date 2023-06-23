import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuestionComponent } from './question/question.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DetailsComponent } from './details/details.component';
import { AddquestionComponent } from './addquestion/addquestion.component';



@NgModule({
  declarations: [
    QuestionComponent,
    DetailsComponent,
    AddquestionComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    QuestionComponent,
    AddquestionComponent
  ]

})
export class ConsultingModule { }
