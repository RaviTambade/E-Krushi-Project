import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from '../Models/Order';

@Injectable({
  providedIn: 'root',
})
export class StoreService {
  constructor(private httpClient: HttpClient) {}

  getStoreUserId(storeId: number): Observable<number> {
    let url = 'http://localhost:5226/api/stores/user/' + storeId;
    return this.httpClient.get<number>(url);
  }

  getStoreOrders(storeId: number,orderStatus:string): Observable<Order[]> {
    let url = 'http://localhost:5226/api/stores/' + storeId +'/'+orderStatus;
    return this.httpClient.get<Order[]>(url);
  }

  getStoreId(userId: number): Observable<number> {
    let url = ' http://localhost:5226/api/stores/storeId/' + userId;
    return this.httpClient.get<number>(url);
  }
}
