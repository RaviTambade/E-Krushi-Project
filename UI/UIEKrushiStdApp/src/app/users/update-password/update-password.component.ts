import { Component, EventEmitter, Output } from '@angular/core';
import { UpdatePassword } from 'src/app/Models/update-password';
import { AuthenticationService } from 'src/app/Services/authentication.service';

@Component({
  selector: 'update-password',
  templateUrl: './update-password.component.html',
  styleUrls: ['./update-password.component.css']
})
export class UpdatePasswordComponent {
 credential:UpdatePassword={
   oldPassword: '',
   newPassword: ''
 }
  confirmPassword: any;

  @Output()onPasswordChange=new EventEmitter()
  constructor(private authsvc:AuthenticationService){}

  ngAfterViewInit(): void{
    window.scrollTo(0,document.body.scrollHeight);
  }
  
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
     

      this.authsvc.updatePassword(this.credential).subscribe((response) => {
       
        if (response) {
          alert("Password changed")
          this.onPasswordChange.emit();
        }
        else {
          alert("OldPassword is wrong")
        }
      })
    }  else{
      alert("password dosen't match")
    }
  }

  onCancelClick(){
    this.onPasswordChange.emit();
  }
  
}
