import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CartItem } from '../Models/cart-item';
import { Observable } from 'rxjs';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';
import { AddItem } from '../Models/addItem';
import { LocalStorageKeys } from '../Models/Enums/local-storage-keys';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  constructor(private httpClient: HttpClient) {}

  getCartItems(): Observable<CartItem[]> {
    let userId = localStorage.getItem(LocalStorageKeys.userId);
    let url = 'http://localhost:5282/api/cart/customer/' + userId;
    return this.httpClient.get<CartItem[]>(url);
  }

  updateQuantity(cartItemId: number, quantity: number): Observable<boolean> {
    let url =
      'http://localhost:5282/api/cart/item/' +
      cartItemId +
      '/quantity/' +
      quantity;
    return this.httpClient.put<boolean>(url, {});
  }

  RemoveItem(cartItemId: number): Observable<boolean> {
    let url = 'http://localhost:5282/api/cart/remove/' + cartItemId;
    return this.httpClient.delete<boolean>(url);
  }

  addItem(item: AddItem): Observable<boolean> {
    let url = 'http://localhost:5282/api/cart/';
    return this.httpClient.post<boolean>(url, item);
  }

  isProductInCart(item: AddItem): Observable<boolean> {
    let url = 'http://localhost:5282/api/cart/product/present';
    return this.httpClient.post<boolean>(url, item);
  }
}
