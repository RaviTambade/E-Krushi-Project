import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { CustomerdetailsComponent } from './customerdetails/customerdetails.component';
import { FormsModule } from '@angular/forms';
import { InsertcustomerComponent } from './insertcustomer/insertcustomer.component';
import { UpdatecustomerComponent } from './updatecustomer/updatecustomer.component';
import { GetcustomerComponent } from './getcustomer/getcustomer.component';



@NgModule({
  declarations: [
    CustomerListComponent,
    CustomerdetailsComponent,
    InsertcustomerComponent,
    UpdatecustomerComponent,
    GetcustomerComponent
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
export class CRMModule { }
