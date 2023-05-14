import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SolutionlistComponent } from './solutionlist/solutionlist.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { SolutiondetailsComponent } from './solutiondetails/solutiondetails.component';
import { FormsModule } from '@angular/forms';
import { AddsolutionComponent } from './addsolution/addsolution.component';
import { UpdatesolutionComponent } from './updatesolution/updatesolution.component';
import { GetsolutionComponent } from './getsolution/getsolution.component';



@NgModule({
  declarations: [
    SolutionlistComponent,
    SolutiondetailsComponent,
    AddsolutionComponent,
    UpdatesolutionComponent,
    GetsolutionComponent
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
export class SolutionModule { }
