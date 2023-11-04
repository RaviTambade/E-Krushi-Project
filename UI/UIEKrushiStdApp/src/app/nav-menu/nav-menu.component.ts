import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../Services/user.service';
import { AuthenticationService } from '../Services/authentication.service';
import { LocalStorageKeys } from '../Models/Enums/local-storage-keys';
import { Role } from '../Models/Enums/role';
import { Subscription, switchMap } from 'rxjs';
import { StoreService } from '../Services/store.service';
import { SupplierService } from '../Services/supplier.service';
import { CorporateService } from '../Services/corporate.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],
})
export class NavMenuComponent implements OnInit, OnDestroy {
  isExpanded = false;
  showLinks = false;
  name: string | undefined;
  Role = Role;
  roles: string[] = [];
  storeName: string = '';
  corporateName: string = '';
  reloadNavSubscription: Subscription | undefined;

  constructor(
    private router: Router,
    private usersvc: UserService,
    private storesvc: StoreService,
    private suppliersvc: SupplierService,
    private authsvc: AuthenticationService,
    private corporatesvc: CorporateService,
    private jwthelper:JwtHelperService
  ) {}

  ngOnInit(): void {

    this.fetchNameAndRoles();

    this.reloadNavSubscription = this.usersvc.reloadnavbar.subscribe(() => {
      setTimeout(() => {
        this.fetchNameAndRoles();
      }, 1000);
    });
  }

  isUserHaveRequiredRole(role: string): boolean {
    if (this.roles.includes(role)) {
      return true;
    } else {
      return false;
    }
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  isLoggedIn(): boolean {
    let jwt = localStorage.getItem(LocalStorageKeys.jwt);
    return !this.jwthelper.isTokenExpired(jwt)
  }

  fetchNameAndRoles() {
    const roles = localStorage.getItem(LocalStorageKeys.roles);
    if (roles != null) {
      this.roles = JSON.parse(roles);
    }
    this.fetchStoreName();
    this.fetchCorporateName();

    let contactNumber = this.authsvc.getContactNumberFromToken();
    if (contactNumber != null) {
      this.usersvc.getUserByContact(contactNumber).subscribe((response) => {
       
        this.name = response.name;
      });
    }
  }

  fetchStoreName() {
    const storeId = Number(localStorage.getItem(LocalStorageKeys.storeId));
    if (Number.isNaN(storeId) || storeId == 0) {
      return;
    }
    this.storesvc.getStoreName(storeId).subscribe((res) => {
      this.storeName = res.name;
    });
  }

  fetchCorporateName() {
    const supplierId = Number(
      localStorage.getItem(LocalStorageKeys.supplierId)
    );
    if (Number.isNaN(supplierId) || supplierId == 0) {
      return;
    }
    this.suppliersvc.getCorporateIdOfSupplier(supplierId).pipe(
      switchMap(corporateId => this.corporatesvc.getCorporateName(corporateId))
    ).subscribe(res => {
      this.corporateName = res[0].name;
    }); 
    
  }

  onLogOut() {
    this.storeName = '';
    this.corporateName = '';
    this.roles=[]
    localStorage.clear();
    this.router.navigate(['login']);
  }

  ngOnDestroy(): void {
    this.reloadNavSubscription?.unsubscribe();
  }
}
