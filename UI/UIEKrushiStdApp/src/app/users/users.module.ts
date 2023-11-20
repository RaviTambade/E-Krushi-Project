import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EdituserComponent } from './edituser/edituser.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserprofileComponent } from './userprofile/userprofile.component';
import { Route, RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { UpdatePasswordComponent } from './update-password/update-password.component';


export const userRoutes:Routes=[
  {path:'profile',component:UserprofileComponent},
  {path:'update/details',component:EdituserComponent},
  // {path:'userinfo/updatepassword',component:UpdatePasswordComponent}
]
@NgModule({
  declarations: [
    EdituserComponent,
    UserprofileComponent,
    UpdatePasswordComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    RouterModule,
    ReactiveFormsModule
  ],
  exports:[
    EdituserComponent,
    UserprofileComponent,
  ]
})
export class UsersModule { }
