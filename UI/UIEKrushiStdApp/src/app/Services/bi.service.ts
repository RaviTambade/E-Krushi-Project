import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OrderCount } from '../Models/orderCount';
import { TopProduct } from '../Models/top-product';
import { MonthOrderCount } from '../Models/month-order-count';

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
