import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Item } from './items';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private http:HttpClient) { }

   public getCartId(userId:number):Observable<any>{
    let url ="http://localhost:5282/api/cart/getcartid/" +userId;
    return this.http.get<any>(url);
    }

    public addToCart(item:Item):Observable<any>{
      let url ="http://localhost:5282/api/cart/addtocart";
      return this.http.post<Item>(url,item);
      }

      public removeFromCart(productId:number):Observable<any>{
        let url ="http://localhost:5282/api/cart/remove/" +productId;
        return this.http.delete<any>(url);
      }
  
      public getCartDetails(custId:number):Observable<any>{
        let url = "http://localhost:5282/api/cart/getcart/" +custId;
        return this.http.get<any>(url);
      }
}
