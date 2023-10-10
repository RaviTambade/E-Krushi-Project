import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OrderCount } from '../Models/orderCount';

@Injectable({
  providedIn: 'root'
})
export class BIService {

  constructor(private httpClient:HttpClient) { }



  getOrderCountByStore(todaysDate :string,storeId: number): Observable<OrderCount> {
    let url = ' http://localhost:5161/api/bi/orderscount/' + todaysDate+"/" + storeId;
    return this.httpClient.get<OrderCount>(url);
  }
}
