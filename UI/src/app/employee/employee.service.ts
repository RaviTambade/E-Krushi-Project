import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Item } from './items';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http:HttpClient) { }

  public getAllProducts():Observable<any>{
    let url = "http://localhost:5137/api/products";
    return this.http.get<any>(url);
  }

  public getById(id:any):Observable<any>{
    let url = "http://localhost:5137/api/products/product/" +id;
    return this.http.get<any>(url);
  }

  public getCartId(id:number):Observable<any>{
  let url ="http://localhost:5282/api/cart/getcartid/" +id;
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

    public updateQuantity(item:Item):Observable<any>{
      let url = " http://localhost:5282/api/cart/update" 
      return this.http.put<any>(url,item);
    }


    public get(cartItemId:number):Observable<any>{
      let url = "http://localhost:5282/api/cart/get/" +cartItemId;
      return this.http.get<any>(url);
    }

    public getOrderDetails(custId:number):Observable<any>{
      let url ="http://localhost:5057/api/orders/orderhistory/" +custId;
      return this.http.get<any>(url);
      }

      public getAllOrders():Observable<any>{
        let url = "http://localhost:5057/api/orders/customerorders";
        return this.http.get<any>(url);
      }

      public getDetails(orderId:number):Observable<any>{
        let url = "http://localhost:5057/orderdetails/order/"+orderId;
        return this.http.get<any>(url);
      }
      public getCustomer(custId:number):Observable<any>{
        let url = "http://localhost:5027/api/customer/getcustomer/" +custId;
        return this.http.get<any>(url);
      }
}


