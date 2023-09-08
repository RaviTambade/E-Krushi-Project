import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SigninComponent } from './signin/signin.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NewuserComponent } from './newuser/newuser.component';
import { LogoutComponent } from './logout/logout.component';




@NgModule({
  declarations: [
    SigninComponent,
    LoginComponent,
    RegisterComponent,
    NewuserComponent,
    LogoutComponent
    

  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    
  ],
  exports: [
    RegisterComponent,
    LoginComponent,
    NewuserComponent
   
  ]
})
export class AuthenticationModule { }
