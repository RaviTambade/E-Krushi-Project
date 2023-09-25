import { Injectable } from '@angular/core';
import { Order } from '../Models/Order';
import { OrderedItem } from '../Models/orderdItem';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { OrderDetails } from '../Models/orderDetails';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  public sendOrderData=new Subject();
  
  constructor(private httpClient: HttpClient) {}

  getOrdersOfCustomer(customerid:number):Observable<Order[]>{
    let url = 'http://localhost:5057/api/orders/customerorders/'+customerid;
    return this.httpClient.get<Order[]>(url);
  }

  

  getOrdersDetails(orderId:number):Observable<OrderDetails[]>{
    let url = 'http://localhost:5057/api/orderdetails/order/'+orderId;
    return this.httpClient.get<OrderDetails[]>(url);
  }


  getOrder(orderId:number):Observable<Order>{
    let url = 'http://localhost:5057/api/orders/customerorders/orderId/'+orderId;
    return this.httpClient.get<Order>(url);
  }
}
