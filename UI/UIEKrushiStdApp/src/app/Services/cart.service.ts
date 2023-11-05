import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CartItem } from '../Models/cart-item';
import { Observable } from 'rxjs';
import { Cart } from '../Models/cart';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CartService {

  private apiurl: string = environment.cartServiceUrl;

  constructor(private httpClient: HttpClient) {}

  getCartItems(): Observable<Cart> {
    let url = this.apiurl;
    console.log("🚀 ~ getCartItems ~ apiurl:", this.apiurl);
    return this.httpClient.get<Cart>(url,{withCredentials:true});
  }

  updateQuantity(productDetailsId: number, quantity: number): Observable<boolean> {
    let url = `${this.apiurl}/items/${productDetailsId}/quantity/${quantity}`;
    return this.httpClient.put<boolean>(url,{},{withCredentials:true});
  }

  RemoveItem(productDetailsId: number): Observable<boolean> {
    let url = `${this.apiurl}/items/remove/${productDetailsId}`;
    return this.httpClient.delete<boolean>(url,{withCredentials:true});
  }
  
  RemoveAllCartItems(): Observable<boolean> {
    let url = `${this.apiurl}/items/removeall`;
    return this.httpClient.delete<boolean>(url,{withCredentials:true});
  }

  addItem(item: CartItem): Observable<boolean> {
    let url = this.apiurl;
    return this.httpClient.post<boolean>(url, item,{withCredentials:true});
  }

  isProductInCart(productDetailsId:number): Observable<boolean> {
    let url = `${this.apiurl}/items/product/ispresent/${productDetailsId}`;
    return this.httpClient.get<boolean>(url,{withCredentials:true});
  }

}
