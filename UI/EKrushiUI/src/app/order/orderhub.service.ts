import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class OrderhubService {

  constructor(private http:HttpClient) { 
  }

    public filterDate(fromDate:string,toDate:string):Observable<any>{
      let url="http://localhost:5057/api/orders/orderDate/" +fromDate+ "/" +toDate;
      return this.http.get<any>(url);
    }

    
    public getCustomer(userId:number):Observable<any>{
      let url = "http://localhost:5027/api/customers/customer/" +userId;
      return this.http.get<any>(url);
    }

    public getOrderDetails(userId:number):Observable<any>{
      let url ="http://localhost:5057/api/orders/orderhistory/" +userId;
      return this.http.get<any>(url);
      }


     
}


