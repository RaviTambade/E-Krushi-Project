import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CartItem } from '../Models/cart-item';
import { Observable } from 'rxjs';
import { AddItem } from '../Models/addItem';
import { LocalStorageKeys } from '../Models/Enums/local-storage-keys';
import { Cart } from '../Models/cart';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  constructor(private httpClient: HttpClient) {}

  getCartItems(): Observable<Cart> {
    let url = 'http://localhost:5282/api/carts';
    return this.httpClient.get<Cart>(url,{withCredentials:true});
  }

  updateQuantity(productDetailsId: number, quantity: number): Observable<boolean> {
    let url =
      'http://localhost:5282/api/carts/items/' +
      productDetailsId +
      '/quantity/' +
      quantity;
    return this.httpClient.put<boolean>(url,{},{withCredentials:true});
  }

  RemoveItem(productDetailsId: number): Observable<boolean> {
    let url = 'http://localhost:5282/api/carts/items/remove/' +  productDetailsId;
    return this.httpClient.delete<boolean>(url,{withCredentials:true});
  }
  
  RemoveAllCartItems(): Observable<boolean> {
    let url = 'http://localhost:5282/api/carts/items/removeall';
    return this.httpClient.delete<boolean>(url,{withCredentials:true});
  }

  addItem(item: CartItem): Observable<boolean> {
    let url = 'http://localhost:5282/api/carts';
   
   
    return this.httpClient.post<boolean>(url, item,{withCredentials:true});
  }

  isProductInCart(productDetailsId:number): Observable<boolean> {
    let url = 'http://localhost:5282/api/carts/items/product/ispresent/'+productDetailsId;
    return this.httpClient.get<boolean>(url,{withCredentials:true});
  }

}
