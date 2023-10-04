import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../Services/user.service';
import { AuthenticationService } from '../Services/authentication.service';
import { LocalStorageKeys } from '../Models/Enums/local-storage-keys';
import { Role } from '../Models/Enums/role';
import { Subscription } from 'rxjs';

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
  reloadNavSubscription: Subscription | undefined;

  constructor(
    private router: Router,
    private userService: UserService,
    private authService: AuthenticationService
  ) {}

  ngOnInit(): void {
    this.fetchNameAndRoles();
    
    this.reloadNavSubscription = this.userService.reloadnavbar.subscribe(() => {
      this.fetchNameAndRoles();
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
    let contactNumber = this.authService.getContactNumberFromToken();
    if (contactNumber != null) {
      this.userService.getUserByContact(contactNumber).subscribe((response) => {
        console.log(response);
        this.name = response.name;
      });
    }

    let userId = localStorage.getItem(LocalStorageKeys.userId);
    if (userId !== null) {
      this.userService.getUserRole(Number(userId)).subscribe((res) => {
        this.roles = res;
      });
    }
  }

  logOut() {
    localStorage.clear();
    this.router.navigate(['login']);
  }

  ngOnDestroy(): void {
    this.reloadNavSubscription?.unsubscribe();
  }
}
