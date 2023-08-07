import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SigninComponent } from './signin/signin.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NewuserComponent } from './newuser/newuser.component';
import { PersonalInfoRegistrationComponent } from './personal-info-registration/personal-info-registration.component';



@NgModule({
  declarations: [
    SigninComponent,
    LoginComponent,
    RegisterComponent,
    NewuserComponent,
    PersonalInfoRegistrationComponent,

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
    NewuserComponent,
    PersonalInfoRegistrationComponent
  ]
})
export class AuthenticationModule { }
