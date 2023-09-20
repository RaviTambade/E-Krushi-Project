import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CartItem } from '../Models/cart-item';
import { Observable } from 'rxjs';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  constructor(private httpClient: HttpClient) {}

  getCartItems(): Observable<CartItem[]> {
    let userId = localStorage.getItem('userId');
    let url = 'http://localhost:5282/api/cart/customer/' + userId;
    return this.httpClient.get<CartItem[]>(url);
  }

  updateQuantity(cartItemId:number,quantity:number):Observable<boolean>{
    let url = 'http://localhost:5282/api/cart/item/' + cartItemId +'/quantity/'+quantity;
    return this.httpClient.put<boolean>(url,{});
  }


}
