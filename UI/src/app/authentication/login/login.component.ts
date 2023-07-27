import { Component } from '@angular/core';
import { AuthenticationService } from '../authentication.service';
import { Credential } from '../Credential';
import { Router } from '@angular/router';
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

  constructor(private svc: AuthenticationService,private router:Router) {
    // this.productId=localStorage.getItem("")
   }

  onLogin(form: any) {
    console.log(form);
    this.svc.validate(form).subscribe((response) => {
      console.log(response);
      localStorage.setItem("contactNumber",response.contactNumber);
      localStorage.setItem("jwt",response.token)
      if(response){
        this.router.navigate(['home']);
      } 
    })
  }
}
