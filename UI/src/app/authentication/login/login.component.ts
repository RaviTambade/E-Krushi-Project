import { Component } from '@angular/core';
import { AuthenticationService } from '../authentication.service';
import { Credential } from '../Credential';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  credential: Credential = {
    contactNumber: '',
    password: ''
  }

  constructor(private svc: AuthenticationService) { }

  onLogin(form: any) {
    console.log(form);
    this.svc.validate(form).subscribe((response) => {
      console.log(response);
      localStorage.setItem("jwt",response.token)
      alert("Login sucessfull")

    })
  }
}
