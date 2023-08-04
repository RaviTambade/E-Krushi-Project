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



    public orderStatus(year:any):Observable<any>{
      let url="http://localhost:5057/api/orders/order/"+year;
      return this.http.get<any>(url);
    }
}
