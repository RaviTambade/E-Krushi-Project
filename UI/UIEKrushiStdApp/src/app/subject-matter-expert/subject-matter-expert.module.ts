import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SubjetcMatterExpertDashboardComponent } from './subjetc-matter-expert-dashboard/subjetc-matter-expert-dashboard.component';
import { Routes } from '@angular/router';
import { SmequestionsComponent } from './smequestions/smequestions.component';
import { UnsolvedquestionsComponent } from './unsolvedquestions/unsolvedquestions.component';

export const subjetcMatterExpertRoutes: Routes = [
  { path: 'dashboard', component: SubjetcMatterExpertDashboardComponent },
];

@NgModule({
  declarations: [
    SubjetcMatterExpertDashboardComponent,
    SmequestionsComponent,
    UnsolvedquestionsComponent
  ],
  imports: [
    CommonModule
  ]
})
export class SubjectMatterExpertModule { }
