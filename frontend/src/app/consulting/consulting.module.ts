import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuestionComponent } from './question/question.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DetailsComponent } from './details/details.component';
import { AddquestionComponent } from './addquestion/addquestion.component';
import { MyquestionComponent } from './myquestion/myquestion.component';



@NgModule({
  declarations: [
    QuestionComponent,
    DetailsComponent,
    AddquestionComponent,
    MyquestionComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    QuestionComponent,
    AddquestionComponent,
    MyquestionComponent
  ]

})
export class ConsultingModule { }
