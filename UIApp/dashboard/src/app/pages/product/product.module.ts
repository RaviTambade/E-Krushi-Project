import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GetproductlistbycategoryComponent } from './getproductlistbycategory/getproductlistbycategory.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductdetailsComponent } from './productdetails/productdetails.component';
import { NewproductComponent } from './newproduct/newproduct.component';



@NgModule({
  declarations: [
    GetproductlistbycategoryComponent,
    ProductdetailsComponent,
    NewproductComponent
  ],
  imports: [
    CommonModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    ReactiveFormsModule,
    FormsModule
  ],
  exports: [
    GetproductlistbycategoryComponent
  ]
})
export class ProductModule { }
