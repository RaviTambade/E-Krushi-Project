import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [
    { path: '/dashboard', title: 'Dashboard',  icon: 'ni-tv-2 text-primary', class: '' },
    { path: '/icons', title: 'Icons',  icon:'ni-planet text-blue', class: '' },
    { path: '/maps', title: 'Maps',  icon:'ni-pin-3 text-orange', class: '' },
    { path: '/user-profile', title: 'User profile',  icon:'ni-single-02 text-yellow', class: '' },
    { path: '/tables', title: 'Tables',  icon:'ni-bullet-list-67 text-red', class: '' },
    { path: '/login', title: 'Login',  icon:'ni-key-25 text-info', class: '' },
    { path: '/register', title: 'Register',  icon:'ni-circle-08 text-pink', class: '' },
    // { path: '/productlist', title: 'Product list',  icon:'ni-circle-08 text-pink', class: '' },
    // { path: '/details', title: 'Details',  icon:'ni-circle-08 text-pink', class: '' },
    // { path: '/customerlist', title: 'Customer',  icon:'ni-circle-08 text-pink', class: '' },
    // { path: '/customerdetails', title: 'Customer details',  icon:'ni-circle-08 text-pink', class: '' },
    // { path: '/insertcustomer', title: 'Insert Customer',  icon:'ni-circle-08 text-pink', class: '' },
    // { path: '/updatecustomer', title: 'Update Customer',  icon:'ni-circle-08 text-pink', class: '' },
    { path: '/categorylist', title: 'Category list',  icon:'ni-circle-08 text-pink', class: '' },
    { path: '/categoryDetails', title: 'Category details',  icon:'ni-circle-08 text-pink', class: '' },
    { path: '/addcategory', title: 'Add Category',  icon:'ni-circle-08 text-pink', class: '' },
    { path: '/updatecategory', title: 'Update Category',  icon:'ni-circle-08 text-pink', class: '' },
    { path: '/agridoctorslist', title: 'Agri Doctors',  icon:'ni-circle-08 text-pink', class: '' }
  ];


@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  public menuItems: any[];
  public isCollapsed = true;

  constructor(private router: Router) { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
    this.router.events.subscribe((event) => {
      this.isCollapsed = true;
   });
  }
}
