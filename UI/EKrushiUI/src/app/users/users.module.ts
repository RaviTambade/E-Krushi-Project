import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserprofileComponent } from './userprofile/userprofile.component';
import { HttpClientModule } from '@angular/common/http';
import { EdituserComponent } from './edituser/edituser.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ResetpasswordComponent } from './resetpassword/resetpassword.component';
import { ChangecontactnumberComponent } from './changecontactnumber/changecontactnumber.component';



@NgModule({
  declarations: [
    UserprofileComponent,
    EdituserComponent,
    ResetpasswordComponent,
    ChangecontactnumberComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    RouterModule
  ],
  exports: [
    UserprofileComponent,
    EdituserComponent,
    ResetpasswordComponent,
    ChangecontactnumberComponent
  ]
})
export class UsersModule { }
