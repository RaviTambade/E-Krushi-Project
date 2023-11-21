import { Component } from '@angular/core';
import { AuthenticationService } from '@services/authentication.service';
import { Router } from '@angular/router';
import { LocalStorageKeys } from '@enums/local-storage-keys';
import { Role } from '@enums/role';
import { TokenClaims } from '@enums/tokenclaims';
import { ShipperService } from '@services/shipper.service';
import { StoreService } from '@services/store.service';
import { SupplierService } from '@services/supplier.service';
import { UserService } from '@services/user.service';

@Component({
  selector: 'app-login-component',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  lob: string = 'EKrushi';
  roles: string[] = [];
  istokenReceived: boolean = false;

  constructor(
    private router: Router,
    private authService: AuthenticationService,
    private userService: UserService,
    private storesvc: StoreService,
    private suppliersvc: SupplierService,
    private shippersvc: ShipperService
  ) {}

  onReceiveToken(event: any) {
    if (event.token) {
      localStorage.setItem(LocalStorageKeys.jwt, event.token);
      this.roles = this.authService.getRolesFromToken();
      if (this.roles?.length == 1) {
        const role = this.roles[0];
        this.navigateByRole(role);
      } else if (this.roles?.length > 1) {
        this.istokenReceived = true;
      }
    }
  }

  navigateByRole(role: string) {
    let userId = Number(this.authService.getClaimFromToken(TokenClaims.userId));
    switch (role) {
      case Role.customer:
        this.router.navigate(['/home']);
        break;
      case Role.storeOwner:
        this.storesvc.getStoreId(userId).subscribe((res) => {
          localStorage.setItem(LocalStorageKeys.storeId, res.toString());
          this.router.navigate(['store/dashboard']);
        });
        break;
      case Role.supplier:
        this.suppliersvc.getSupplierId(userId).subscribe((res) => {
          localStorage.setItem(LocalStorageKeys.supplierId, res.toString());
          this.router.navigate(['supplier/dashboard']);
        });
        break;
      case Role.shipper:
        this.shippersvc.getShipperId(userId).subscribe((res) => {
          localStorage.setItem(LocalStorageKeys.shipperId, res.toString());
          this.router.navigate(['shipper/dashboard']);
        });
        break;
      case Role.subjectMatterExpert:
        this.router.navigate(['sme/dashboard']);
        break;
    }
    this.istokenReceived = false;
    this.userService.reloadnavbar.next();
  }
}
