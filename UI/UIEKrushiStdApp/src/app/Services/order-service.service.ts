import { Injectable } from '@angular/core';
import { Order } from '../Models/Order';
import { OrderedItem } from '../Models/orderdItem';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { OrderDetails } from '../Models/orderDetails';
import { OrderAddModel } from '../Models/order-add-model';
import { OrderAmount } from '../Models/order-amount';
import { OrdereUpdate } from '../Models/orderupdate';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  public sendOrderData = new Subject();

  constructor(private httpClient: HttpClient) {}

  getOrdersOfCustomer(customerId: number,orderStatus:string): Observable<Order[]> {
    let url = 'http://localhost:5059/api/orders/customers/' + customerId +'/'+orderStatus;
    return this.httpClient.get<Order[]>(url);
  }

  getOrdersDetails(orderId: number): Observable<OrderDetails[]> {
    let url = 'http://localhost:5059/api/orders/details/' + orderId;
    return this.httpClient.get<OrderDetails[]>(url);
  }

  getOrderAmount(orderId: number): Observable<number> {
    let url = 'http://localhost:5059/api/orders/amount/' + orderId;
    return this.httpClient.get<number>(url);
  }

  createOrder(order: OrderAddModel): Observable<OrderAmount> {
    let url = 'http://localhost:5059/api/orders/';
    return this.httpClient.post<OrderAmount>(url, order);
  }

  getAddressIdOfOrder(orderId: number): Observable<number> {
    let url = 'http://localhost:5059/api/orders/delivery/address/' + orderId;
    return this.httpClient.get<number>(url);
  }

  updateOrderStatus(orderId:number,status:string): Observable<boolean> {
   let order: OrdereUpdate={
      orderId:orderId,
      status:status
    };
    let url = 'http://localhost:5059/api/orders/update/status';
    return this.httpClient.patch<boolean>(url,order);
  }
}
