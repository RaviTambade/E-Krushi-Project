import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuestionComponent } from './question/question.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DetailsComponent } from './details/details.component';
import { AddquestionComponent } from './addquestion/addquestion.component';
import { MyquestionComponent } from './myquestion/myquestion.component';
import { NewquestionComponent } from './newquestion/newquestion.component';
import { QuestioncategoryComponent } from './questioncategory/questioncategory.component';
import { HttpClientModule } from '@angular/common/http';
import { QuestionanswerComponent } from './questionanswer/questionanswer.component';





@NgModule({
  declarations: [
    QuestionComponent,
    DetailsComponent,
    AddquestionComponent,
    MyquestionComponent,
    NewquestionComponent,
    QuestioncategoryComponent,
    QuestionanswerComponent,
    
    
  ],
  imports: [
    CommonModule,
    FormsModule,
   HttpClientModule,
    ReactiveFormsModule
  ],
  exports: [
    QuestionComponent,
    AddquestionComponent,
    MyquestionComponent,
    NewquestionComponent,
    QuestioncategoryComponent
  ]

})
export class ConsultingModule { }
