import { Component } from '@angular/core';
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
  userId!: number;
  roles: string[] = [];

  constructor(
    private router: Router,
    private authService: AuthenticationService,
    private userService: UserService,
    private storesvc: StoreService,
    private suppliersvc: SupplierService,
    private shippersvc: ShipperService
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
          localStorage.setItem(LocalStorageKeys.jwt, response.token);
          this.roles = this.authService.getRolesFromToken();
          if (this.roles?.length == 1) {
            const role = this.roles[0];
            this.navigateByRole(role);
          }
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
    this.userId = Number(
      this.authService.getClaimFromToken(TokenClaims.userId)
    );
    switch (role) {
      case Role.customer:
        this.router.navigate(['/home']);
        break;
      case Role.storeOwner:
        this.storesvc.getStoreId(this.userId).subscribe((res) => {
          localStorage.setItem(LocalStorageKeys.storeId, res.toString());
          this.router.navigate(['shop/dashboard']);
        });
        break;
      case Role.supplier:
        this.suppliersvc.getSupplierId(this.userId).subscribe((res) => {
          localStorage.setItem(LocalStorageKeys.supplierId, res.toString());
          this.router.navigate(['supplier/dashboard']);
        });
        break;
      case Role.shipper:
        this.shippersvc.getShipperId(this.userId).subscribe((res) => {
          localStorage.setItem(LocalStorageKeys.shipperId, res.toString());
          this.router.navigate(['shipper/dashboard']);
        });
        break;
      case Role.subjectMatterExpert:
        this.router.navigate(['sme/dashboard']);
        break;
    }
    this.userService.reloadnavbar.next();
  }
}
