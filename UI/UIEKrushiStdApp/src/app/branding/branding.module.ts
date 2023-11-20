import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { SharedModule } from '@ekrushi-shared/shared.module';
import { RouterModule, Routes } from '@angular/router';
import { UserprofileComponent } from './userprofile/userprofile.component';
import { MembershipLibModule } from 'membership-lib';

export const brandingRoutes:Routes=[
  {path:'profile',component:UserprofileComponent},
]
@NgModule({
  declarations: [NavMenuComponent,UserprofileComponent],
  imports: [CommonModule,SharedModule,RouterModule.forRoot(brandingRoutes),MembershipLibModule],
  exports: [NavMenuComponent],
})
export class BrandingModule {}
