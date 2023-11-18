import { Component, EventEmitter, Output } from '@angular/core';
import { Route, Router } from '@angular/router';
import { LocalStorageKeys } from '@enums/local-storage-keys';
import { Role } from '@enums/role';
import { AuthenticationService } from '@services/authentication.service';
import { ShipperService } from '@services/shipper.service';
import { StoreService } from '@services/store.service';
import { SupplierService } from '@services/supplier.service';
import { UserService } from '@services/user.service';
import { Credential } from '@models/credential';
import { UserRoleService } from '@services/userrole.service';
import { TokenClaims } from '@enums/tokenclaims';

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
 
  @Output() validSignIn =new EventEmitter<any>();

  constructor(
    private authService: AuthenticationService,
  ) {}

  onSignIn() {
    this.isLoginButtonDisabled = true; 
    this.authService.signIn(this.credential).subscribe({
      next: (response) => {
        if (response.token == "" || !response) {
          this.isCredentialInvalid = true;
          setTimeout(() => {
            this.isCredentialInvalid = false;
          }, 3000);
        }
        if (response.token != "") {
          this.validSignIn.emit({token:response.token});
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


}
