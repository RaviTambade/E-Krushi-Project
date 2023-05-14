import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategorylistComponent } from './categorylist/categorylist.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { FormsModule } from '@angular/forms';
import { CategorydetailsComponent } from './categorydetails/categorydetails.component';
import { AddcategoryComponent } from './addcategory/addcategory.component';



@NgModule({
  declarations: [
    CategorylistComponent,
    CategorydetailsComponent,
    AddcategoryComponent
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
export class CategoryModule { }
