import { Component } from '@angular/core';
import { AuthenticationService } from '../authentication.service';
import { User } from '../user';

@Component({
  selector: 'app-newuser',
  templateUrl: './newuser.component.html',
  styleUrls: ['./newuser.component.css']
})
export class NewuserComponent {

  status:boolean |undefined;
user:User={
  Id: 0,
  firstName: '',
  lastName: '',
  birthDate: '',
  aadharId: '',
  gender: '',
  email: '',
  contactNumber: ''
}
contactNumber:any;

  constructor(private svc:AuthenticationService){
    this.contactNumber=localStorage.getItem("contactNumber")
  }

  public newUser(form:any){
    console.log(form);
    this.svc.newUser(form).subscribe((res)=>{
    this.status=res;
    console.log(res);
    })
  }
}
