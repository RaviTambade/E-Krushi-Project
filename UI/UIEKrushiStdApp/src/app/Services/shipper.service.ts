import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '@environments/environment';
import { OrderStatusCount } from '@models/order-status-count';
import { ShipperOrder } from '@models/shipper-order';

@Injectable({
  providedIn: 'root',
})
export class ShipperService {
  private apiurl: string = environment.shippersServiceUrl;

  constructor(private httpClient: HttpClient) {}

  getShipperOrders(
    shipperId: number,
    status: string
  ): Observable<ShipperOrder[]> {
    let url = `${this.apiurl}/${shipperId}/${status}`;
    return this.httpClient.get<ShipperOrder[]>(url);
  }

  getShipperId(userId: number): Observable<number> {
    let url = `${this.apiurl}/shipperid/${userId}`;
    return this.httpClient.get<number>(url);
  }

  getOrderCountByStatusAndShipper(shipperId: number ): Observable<OrderStatusCount> {
    let url = `${this.apiurl}/orderscount/${shipperId}`;
    return this.httpClient.get<OrderStatusCount>(url);
  }
}
