import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from '../Models/Order';
import { OrderStatusCount } from '../Models/order-status-count';
import { StoreName } from '../Models/store-name';

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
  getOrderCountByStatusAndStore(storeId: number): Observable<OrderStatusCount> {
    let url = 'http://localhost:5226/api/stores/orderscount/' + storeId ;
    return this.httpClient.get<OrderStatusCount>(url);
  }

  getStoreName(storeId: number): Observable<StoreName> {
    let url = 'http://localhost:5226/api/stores/name/' + storeId ;
    return this.httpClient.get<StoreName>(url);
  }

  getStoreId(userId: number): Observable<number> {
    let url = ' http://localhost:5226/api/stores/storeid/' + userId;
    return this.httpClient.get<number>(url);
  }
}
