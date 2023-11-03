import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { LocalStorageKeys } from 'src/app/Models/Enums/local-storage-keys';
import { SessionStorageKeys } from 'src/app/Models/Enums/session-storage-keys';
import { CartItem } from 'src/app/Models/cart-item';
import { CartService } from 'src/app/Services/cart.service';

@Component({
  selector: 'app-shoppingcart',
  templateUrl: './shoppingcart.component.html',
  styleUrls: ['./shoppingcart.component.css'],
})
export class ShoppingcartComponent implements OnInit {
  items: CartItem[] = [];
  totalItems: string = '';
  subTotal: number = 0;
  discount: number = 0;
  shippingCharges = 'Free';
  total: number = 0;

  maxAllowedQuantity: number = 10;
  minAllowedQuantity: number = 1;
  constructor(
    private cartsvc: CartService,
    private router: Router,
    private jwthelper: JwtHelperService
  ) {}

  ngOnInit(): void {
    this.cartsvc.getCartItems().subscribe((res) => {
      this.items = res.items;
    });
  }
  onReceiveData(event: any) {
    this.totalItems = event.totalItems;
    this.subTotal = event.subTotal;
    this.total = event.total;
  }

  isLoggedIn(): boolean {
    let jwt = localStorage.getItem(LocalStorageKeys.jwt);
    return !this.jwthelper.isTokenExpired(jwt);
  }

  onClickPlaceOrder() {
    if (!this.isLoggedIn()) {
      alert('Please Login First');
      this.router.navigate(['/login']);
      return;
    }
    sessionStorage.setItem(SessionStorageKeys.isBuyNow,'false');
    this.router.navigate(['/orderprocessing']);
  }
}
