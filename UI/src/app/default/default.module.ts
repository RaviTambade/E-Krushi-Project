import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { UserprofileComponent } from './userprofile/userprofile.component';



@NgModule({
  declarations: [
    HomeComponent,
    UserprofileComponent
  ],
  imports: [
    CommonModule
  ]
})
export class DefaultModule { }
