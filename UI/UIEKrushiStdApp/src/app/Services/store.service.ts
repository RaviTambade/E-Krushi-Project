import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from '../Models/Order';
import { OrderStatusCount } from '../Models/order-status-count';
import { StoreName } from '../Models/store-name';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class StoreService {
  private apiurl: string = environment.storesServiceUrl;

  constructor(private httpClient: HttpClient) {}

  getStoreUserId(storeId: number): Observable<number> {
    let url = `${this.apiurl}/user/${storeId}`;
    return this.httpClient.get<number>(url);
  }

  getStoreOrders(storeId: number, orderStatus: string): Observable<Order[]> {
    let url = `${this.apiurl}/${storeId}/${orderStatus}`;
    return this.httpClient.get<Order[]>(url);
  }
  getOrderCountByStatusAndStore(storeId: number): Observable<OrderStatusCount> {
    let url = `${this.apiurl}/orderscount/${storeId}`;
    return this.httpClient.get<OrderStatusCount>(url);
  }

  getStoreName(storeId: number): Observable<StoreName> {
    let url = `${this.apiurl}/name/${storeId}`;
    return this.httpClient.get<StoreName>(url);
  }

  getStoreId(userId: number): Observable<number> {
    let url = `${this.apiurl}/storeid/${userId}`;
    return this.httpClient.get<number>(url);
  }
}
