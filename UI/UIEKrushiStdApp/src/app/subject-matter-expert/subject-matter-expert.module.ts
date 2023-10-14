import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SubjetcMatterExpertDashboardComponent } from './subjetc-matter-expert-dashboard/subjetc-matter-expert-dashboard.component';
import { Routes } from '@angular/router';
import { BlogComponent } from './blog/blog.component';
import { SmequestionsComponent } from './smequestions/smequestions.component';

export const subjetcMatterExpertRoutes: Routes = [
  { path: 'dashboard', component: SubjetcMatterExpertDashboardComponent },
  { path: 'blog', component: BlogComponent },
];

@NgModule({
  declarations: [
    SubjetcMatterExpertDashboardComponent,
    BlogComponent,
    SmequestionsComponent
  ],
  imports: [
    CommonModule
  ]
})
export class SubjectMatterExpertModule { }
