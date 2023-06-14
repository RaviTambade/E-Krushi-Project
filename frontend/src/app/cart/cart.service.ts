import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Item } from './items';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private http:HttpClient) { }
  
   public addToCart(id:number):Observable<any> {
    let url= "http://localhost:5282/api/cart/addtocart/"+ id;
     return this.http.post<any>(url,id);
   }
}
