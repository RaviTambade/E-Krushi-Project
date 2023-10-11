import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OrderCount } from '../Models/orderCount';
import { TopProduct } from '../Models/top-product';

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
}
