import { Component } from '@angular/core';
import { Route, Router } from '@angular/router';
import { LocalStorageKeys } from 'src/app/Models/Enums/local-storage-keys';
import { Role } from 'src/app/Models/Enums/role';
import { Credential } from 'src/app/Models/credential';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { ShipperService } from 'src/app/Services/shipper.service';
import { StoreService } from 'src/app/Services/store.service';
import { UserService } from 'src/app/Services/user.service';
@Component({
  selector: 'app-login-component',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  credential: Credential = {
    contactNumber: '',
    password: '',
  };
  isLoginButtonDisabled: boolean = false;
  isCredentialInvalid: boolean = false;
  userId: number | undefined;
  roles: string[] = [];

  constructor(
    private router: Router,
    private authService: AuthenticationService,
    private userService: UserService,
    private storesvc: StoreService,
    private shippersvc: ShipperService
  ) {}

  onSignIn() {
    this.isLoginButtonDisabled = true;
    console.log('Validating user');
    this.authService.validate(this.credential).subscribe({
      next: (response) => {
        if (response == null || !response) {
          this.isCredentialInvalid = true;
          setTimeout(() => {
            this.isCredentialInvalid = false;
          }, 3000);
        }
        console.log(response);
        if (response != null) {
          localStorage.setItem(LocalStorageKeys.jwt, response.token);
          this.userService
            .getUserByContact(this.credential.contactNumber)
            .subscribe((response) => {
              this.userId = response.id;
              console.log(this.userId);
              localStorage.setItem(
                LocalStorageKeys.userId,
                this.userId.toString()
              );
              this.userService
                .getUserRole(this.userId)
                .subscribe((response) => {
                  this.roles = response;
                  console.log(this.roles);
                  if (this.roles?.length == 1) {
                    const role = this.roles[0];
                    this.navigateByRole(role);
                  }
                });
            });
        }
      },
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        this.isLoginButtonDisabled = false;
      },
    });
  }

  navigateByRole(role: string) {
    this.userService.reloadnavbar.next();
    switch (role) {
      case Role.Customer:
        this.router.navigate(['customer/dashboard']);
        break;
      case Role.ShopOwner:
        if (this.userId != undefined)
          this.storesvc.getStoreId(this.userId).subscribe((res) => {
            localStorage.setItem(LocalStorageKeys.storeId, res.toString());
          });
        this.router.navigate(['shop/dashboard']);
        break;
      case Role.Supplier:
        this.router.navigate(['supplier/dashboard']);
        break;
      case Role.Shipper:
        if (this.userId != undefined)
          this.shippersvc.getShipperId(this.userId).subscribe((res) => {
            localStorage.setItem(LocalStorageKeys.shipperId, res.toString());
          });
        this.router.navigate(['shipper/dashboard']);
        break;
      case Role.SubjectMatterExpert:
        this.router.navigate(['sme/dashboard']);
        break;
    }
  }
  showLoginPage() {
    return this.roles.length < 1;
  }
}
