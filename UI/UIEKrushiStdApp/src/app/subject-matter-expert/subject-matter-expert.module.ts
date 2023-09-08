import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SubjetcMatterExpertDashboardComponent } from './subjetc-matter-expert-dashboard/subjetc-matter-expert-dashboard.component';
import { Routes } from '@angular/router';

export const subjetcMatterExpertRoutes: Routes = [
  { path: 'dashboard', component: SubjetcMatterExpertDashboardComponent },
];

@NgModule({
  declarations: [
    SubjetcMatterExpertDashboardComponent
  ],
  imports: [
    CommonModule
  ]
})
export class SubjectMatterExpertModule { }
