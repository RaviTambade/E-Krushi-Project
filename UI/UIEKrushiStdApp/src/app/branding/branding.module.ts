import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { SharedModule } from '@ekrushi-shared/shared.module';
import { RouterModule, Routes } from '@angular/router';
import { UserprofileComponent } from './userprofile/userprofile.component';
import { UpdateProfileComponent } from './update-profile/update-profile.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { ReactiveFormsModule } from '@angular/forms';

export const brandingRoutes:Routes=[
  {path:'profile',component:UserprofileComponent},
  ]
  @NgModule({
  declarations: [NavMenuComponent,UserprofileComponent,UpdateProfileComponent,ChangePasswordComponent],
  imports: [CommonModule,SharedModule,RouterModule.forRoot(brandingRoutes),ReactiveFormsModule],
  exports: [NavMenuComponent],
})
export class BrandingModule {}
