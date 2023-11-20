import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './register/register.component';
import { LoginRoutingComponent } from './login-routing/login-routing.component';
import { MembershipLibModule } from 'membership-lib';
import { Routes } from '@angular/router';

export const authRoutes: Routes = [
  { path: 'login', component: LoginRoutingComponent },
  { path: 'register', component: RegisterComponent },
];

@NgModule({
  declarations: [LoginComponent, RegisterComponent, LoginRoutingComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MembershipLibModule,
  ],
})
export class AuthenticationModule {}
