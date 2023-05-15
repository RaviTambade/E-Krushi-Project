import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuestionlistComponent } from './questionlist/questionlist.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { QuestiondetailsComponent } from './questiondetails/questiondetails.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    QuestionlistComponent,
    QuestiondetailsComponent
  ],
  imports: [
    CommonModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    FormsModule
  ]
})
export class QuestionModule { }
