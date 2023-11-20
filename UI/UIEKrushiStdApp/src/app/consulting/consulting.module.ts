import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuestionCatagoriesComponent } from './question-catagories/question-catagories.component';
import { ReletedquestionsComponent } from './reletedquestions/reletedquestions.component';
import { CategorywisequestionsComponent } from './categorywisequestions/categorywisequestions.component';
import { RouterModule, Routes } from '@angular/router';
import { QuestionsComponent } from './customer-questions/questions/questions.component';
import { CustomerQuestionsComponent } from './customer-questions/customer-questions.component';
import { AddquestionComponent } from './customer-questions/addquestion/addquestion.component';
import { QuestionanswerComponent } from './customer-questions/questionanswer/questionanswer.component';
import { FormsModule } from '@angular/forms';

export const consultingRoutes: Routes = [
  {
    path: 'categorywisequestions/:categoryId',
    component: CategorywisequestionsComponent,
  },
  { path: 'question', component: CustomerQuestionsComponent },
  { path: 'addquestion', component: AddquestionComponent },
  { path: 'questionHistory', component: QuestionsComponent },
  { path: 'question/:id', component: QuestionanswerComponent },
];

@NgModule({
  declarations: [
    QuestionCatagoriesComponent,
    ReletedquestionsComponent,
    CategorywisequestionsComponent,
    CustomerQuestionsComponent,
    QuestionsComponent,
    AddquestionComponent,
    QuestionanswerComponent,
  ],
  imports: [CommonModule, RouterModule,FormsModule],
})
export class ConsultingModule {}
