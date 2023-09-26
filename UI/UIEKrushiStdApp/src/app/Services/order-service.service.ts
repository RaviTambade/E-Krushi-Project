import { Injectable } from '@angular/core';
import { Order } from '../Models/Order';
import { OrderedItem } from '../Models/orderdItem';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { OrderDetails } from '../Models/orderDetails';
import { OrderAddModel } from '../Models/order-add-model';
import { OrderAmount } from '../Models/order-amount';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  public sendOrderData = new Subject();

  constructor(private httpClient: HttpClient) {}

  getOrdersOfCustomer(customerId: number): Observable<Order[]> {
    let url = 'http://localhost:5059/api/orders/customer/' + customerId;
    return this.httpClient.get<Order[]>(url);
  }

  getOrdersDetails(orderId: number): Observable<OrderDetails[]> {
    let url = 'http://localhost:5059/api/orders/details/' + orderId;
    return this.httpClient.get<OrderDetails[]>(url);
  }

  getOrderAmount(orderId: number): Observable<number> {
    let url =
      'http://localhost:5059/api/orders/amount/' + orderId;
    return this.httpClient.get<number>(url);
  }

  processOrder(order: OrderAddModel): Observable<OrderAmount> {
    let url = 'http://localhost:5059/api/orders/';
    return this.httpClient.post<OrderAmount>(url, order);
  }
  
}
