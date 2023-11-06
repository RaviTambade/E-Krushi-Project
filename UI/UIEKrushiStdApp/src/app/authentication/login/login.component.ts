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
    private userRoleService: UserRoleService,
    private storesvc: StoreService,
    private suppliersvc: SupplierService,
    private shippersvc: ShipperService
  ) { }

  onSignIn() {
    this.isLoginButtonDisabled = true;

    this.authService.validate(this.credential).subscribe({
      next: (response) => {
        if (response == null || !response) {
          this.isCredentialInvalid = true;
          setTimeout(() => {
            this.isCredentialInvalid = false;
          }, 3000);
        }

        if (response != null) {
          localStorage.setItem(LocalStorageKeys.jwt, response.token);
          this.userService
            .getUserByContact(this.credential.contactNumber)
            .subscribe((response) => {
              this.userId = response.id;

              localStorage.setItem(
                LocalStorageKeys.userId,
                this.userId.toString()
              );
              this.userRoleService
                .getUserRole(this.userId)
                .subscribe((response) => {
                  this.roles = response;

                  localStorage.setItem(
                    LocalStorageKeys.roles,
                    JSON.stringify(this.roles)
                  );

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
    switch (role) {
      case Role.Customer:
        this.router.navigate(['/home']);
        break;
      case Role.ShopOwner:
        if (this.userId != undefined)
          this.storesvc.getStoreId(this.userId).subscribe((res) => {
            localStorage.setItem(LocalStorageKeys.storeId, res.toString());
            this.router.navigate(['shop/dashboard']);
          });
        break;
      case Role.Supplier:
        if (this.userId != undefined)
          this.suppliersvc.getSupplierId(this.userId).subscribe((res) => {
            localStorage.setItem(LocalStorageKeys.supplierId, res.toString());
            this.router.navigate(['supplier/dashboard']);
          });
        break;
      case Role.Shipper:
        if (this.userId != undefined)
          this.shippersvc.getShipperId(this.userId).subscribe((res) => {
            localStorage.setItem(LocalStorageKeys.shipperId, res.toString());
            this.router.navigate(['shipper/dashboard']);
          });
        break;
      case Role.SubjectMatterExpert:
        this.router.navigate(['sme/dashboard']);
        break;
    }
    this.userService.reloadnavbar.next();
  }
}
