import { Injectable } from '@angular/core';
import { Order } from '../Models/Order';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { OrderDetails } from '../Models/orderDetails';
import { OrderAddModel } from '../Models/order-add-model';
import { OrderAmount } from '../Models/order-amount';
import { OrdereUpdate } from '../Models/orderupdate';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  private apiurl: string = environment.ordersServiceUrl;

  public sendOrderData = new Subject();

  constructor(private httpClient: HttpClient) {}

  getOrdersOfCustomer(customerId: number,orderStatus:string): Observable<Order[]> {
    let url = `${this.apiurl}/customers/${customerId}/${orderStatus}`;
    return this.httpClient.get<Order[]>(url);
  }

  getOrdersDetails(orderId: number): Observable<OrderDetails[]> {
    let url = `${this.apiurl}/details/${orderId}`;
    return this.httpClient.get<OrderDetails[]>(url);
  }

  getOrderAmount(orderId: number): Observable<number> {
    let url = `${this.apiurl}/amount/${orderId}`;
    return this.httpClient.get<number>(url);
  }

  createOrder(order: OrderAddModel): Observable<OrderAmount> {
    let url = `${this.apiurl}`;
    return this.httpClient.post<OrderAmount>(url, order);
  }

  getAddressIdOfOrder(orderId: number): Observable<number> {
    let url = `${this.apiurl}/delivery/address/${orderId}`;
    return this.httpClient.get<number>(url);
  }

  updateOrderStatus(orderId:number,status:string): Observable<boolean> {
   let order: OrdereUpdate={
      orderId:orderId,
      status:status
    };
    let url = `${this.apiurl}/update/status`;
    return this.httpClient.patch<boolean>(url,order);
  }
}
