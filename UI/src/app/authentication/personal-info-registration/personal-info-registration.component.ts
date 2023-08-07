import { Component, OnInit } from '@angular/core';
import { User } from '../user';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-personal-info-registration',
  templateUrl: './personal-info-registration.component.html',
  styleUrls: ['./personal-info-registration.component.css']
})
export class PersonalInfoRegistrationComponent {
user:User={
  Id: 0,
  firstName: '',
  lastName: '',
  birthDate: '',
  aadharId: '',
  gender: '',
  email: '',
  contactNumber: ''
};

newuser:any|string;
   constructor(private svc:AuthenticationService){}

  



  resisterUser(form:any){

    this.svc.resisterUser(form).subscribe((res)=>{
     this.newuser=res;
    })

  }

}
