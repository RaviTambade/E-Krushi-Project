import { Component } from '@angular/core';
import { ResetPassword } from '../ResetPassword';
import { UsersService } from '../users.service';

@Component({
  selector: 'app-resetpassword',
  templateUrl: './resetpassword.component.html',
  styleUrls: ['./resetpassword.component.css']
})
export class ResetpasswordComponent {

  credential:ResetPassword={
    oldPassword: '',
    newPassword: ''
  }
   confirmPassword: any;
   constructor(private svc:UsersService){}
   
   onUpdatePassword(form: any) {
     if( this.credential.newPassword=='' ||this.credential.oldPassword==''  ){
       alert("please give valid contact or password")
       return;
     }
     if(this.credential.newPassword.length < 8 || this.confirmPassword.length < 8){
       alert("password should be minimum 8 characters ")
       return;
     }
   
     if (this.credential.newPassword === this.confirmPassword) {
       console.log(form)
 
       this.svc.resetPassword(this.credential).subscribe((response) => {
         console.log(response);
         if (response) {
           alert("Password changed")
         }
         else {
           alert("OldPassword is wrong")
         }
       })
     }  else{
       alert("password dosen't match")
     }
   }
}
