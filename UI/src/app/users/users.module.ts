import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserprofileComponent } from './userprofile/userprofile.component';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [
    UserprofileComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule
  ],
  exports: [
    UserprofileComponent
  ]
})
export class UsersModule { }
