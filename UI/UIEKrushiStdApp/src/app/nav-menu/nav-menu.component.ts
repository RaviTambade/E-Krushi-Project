import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../Services/user.service';
import { AuthenticationService } from '../Services/authentication.service';
import { LocalStorageKeys } from '../Models/Enums/local-storage-keys';
import { Role } from '../Models/Enums/role';
import { Subscription } from 'rxjs';
import { StoreService } from '../Services/store.service';

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
  reloadNavSubscription: Subscription | undefined;

  constructor(
    private router: Router,
    private userService: UserService,
    private storesvc: StoreService,
    private authService: AuthenticationService
  ) {}

  ngOnInit(): void {
    this.fetchNameAndRoles();

    this.reloadNavSubscription = this.userService.reloadnavbar.subscribe(() => {
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
    return jwt != null;
  }

  fetchNameAndRoles() {
    const roles = localStorage.getItem(LocalStorageKeys.roles);
    if (roles != null) {
      this.roles = JSON.parse(roles);
    }
    this.fetchStoreName();

    let contactNumber = this.authService.getContactNumberFromToken();
    if (contactNumber != null) {
      this.userService.getUserByContact(contactNumber).subscribe((response) => {
        console.log(response);
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

  logOut() {
    this.storeName = '';
    localStorage.clear();
    this.router.navigate(['login']);
  }

  ngOnDestroy(): void {
    this.reloadNavSubscription?.unsubscribe();
  }

  onClickProjectName() {
    if (this.roles.includes(Role.Customer)) {
      this.router.navigate(['/home']);
    } else if (this.roles.includes(Role.Shipper)) {
      this.router.navigate(['/shipper/dashboard']);
    } else if (this.roles.includes(Role.ShopOwner)) {
      this.router.navigate(['/shop/dashboard']);
    } else this.router.navigate(['/home']);
  }
}
