import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MonthOrderCount } from '@models/month-order-count';
import { OrderCount } from '@models/orderCount';
import { TopProduct } from '@models/top-product';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class BIService {

  constructor(private httpClient:HttpClient) { }

  getOrderCountByStore(todaysDate :string,storeId: number): Observable<OrderCount> {
    let url = ' http://localhost:5161/api/bi/orderscount/' + todaysDate+"/" + storeId;
    return this.httpClient.get<OrderCount>(url);
  }

  getTopFiveSellingProducts(todaysDate :string,mode:string,storeId: number): Observable<TopProduct[]> {
    let url = ' http://localhost:5161/api/bi/topproducts/' + todaysDate+"/"+mode +"/" + storeId;
    return this.httpClient.get<TopProduct[]>(url);
  }


  getMonthsWithOrders(year :number,storeId: number): Observable<MonthOrderCount[]> {
    let url = ' http://localhost:5161/api/bi/MonthOrders/' + year+"/" + storeId;
    return this.httpClient.get<MonthOrderCount[]>(url);
  }

  getCategorywiseProductsCount(todaysDate :string,mode:string,storeId: number): Observable<any[]> {
    let url = ' http://localhost:5161/api/bi/categorywiseproducts/' + todaysDate+"/"+mode +"/" + storeId;
    return this.httpClient.get<any[]>(url);
  }

  getDeliveredOrders(year :number,storeId: number): Observable<any[]> {
    let url = ' http://localhost:5161/api/bi/deliveredorders/' + year+"/" + storeId;
    return this.httpClient.get<any[]>(url);
  }

}
