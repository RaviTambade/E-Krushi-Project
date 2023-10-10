import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ShipperOrder } from '../Models/shipper-order';
import { OrderStatusCount } from '../Models/order-status-count';

@Injectable({
  providedIn: 'root'
})
export class ShipperService {

  constructor(private httpClient: HttpClient) {}

  getShipperOrders(shipperId: number,status:string): Observable<ShipperOrder[]> {
    let url = 'http://localhost:5298/api/shippers/' + shipperId+'/'+status;
    console.log("req send")
    return this.httpClient.get<ShipperOrder[]>(url);
  }

  getShipperId(userId: number): Observable<number> {
    let url = ' http://localhost:5298/api/shippers/shipperid/' + userId;
    return this.httpClient.get<number>(url);
  }

  getOrderCountByStatusAndShipper(shipperId: number): Observable<OrderStatusCount> {
    let url = 'http://localhost:5298/api/shippers/orderscount/' + shipperId ;
    return this.httpClient.get<OrderStatusCount>(url);
  }




}
