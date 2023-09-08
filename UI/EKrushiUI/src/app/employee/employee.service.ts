import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http:HttpClient) { }

  public getCartDetails(custId:number):Observable<any>{
    let url = "http://localhost:5282/api/cart/getcart/" +custId;
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
        let url = "http://localhost:5027/api/customers/customer/" +custId;
        return this.http.get<any>(url);
      }

      public getByCategoryId(id:any):Observable<any>{
        let url = "http://localhost:5137/api/categories/" +id;
        return this.http.get<any>(url);
      }

      public getCustomerReport(custId:number):Observable<any>{
        let url="http://localhost:5161/api/bi/details/" +custId;
        return this.http.get<any>(url);
      }

     
      
}


