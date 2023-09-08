import { Component } from '@angular/core';
import { Route, Router } from '@angular/router';
import { Credential } from 'src/app/Models/credential';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { UserService } from 'src/app/Services/user.service';
@Component({
  selector: 'app-login-component',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  public currentCount = 0;
  credential: Credential = {
    contactNumber: '',
    password: ''
  }
  userId: number | undefined;
  roles: string[] = [];

  constructor(private router: Router, private authService: AuthenticationService, private userService: UserService) { }

  public onSignIn() {
    console.log("Validating user");
    this.authService.validate(this.credential).subscribe((response) => {
      if (response != null) {
        localStorage.setItem("JWT", response.token)
        this.userService.getUserByContact(this.credential.contactNumber).subscribe((response) => {
          this.userId = response.id;
          console.log(this.userId);
          this.userService.getUserRole(this.userId).subscribe((response) => {
            this.roles = response;
            console.log(this.roles);
            const role=this.roles[0]
            this.navigateByRole(role)
          })
        })
      }

    })


  }

  navigateByRole(role: string) {
    switch (role) {
      case "Customer":
        this.router.navigate(["customer/dashboard"])
        break;
      case "Shop owner":
        this.router.navigate(["shop/dashboard"])
        break;
      case "Supplier":
        this.router.navigate(["supplier/dashboard"])
        break;
      case "Shipper":
        this.router.navigate(["shipper/dashboard"])
        break;
      case "SubjectMatterExpert":
        this.router.navigate(["sme/dashboard"])
        break;
    }











  }

}

