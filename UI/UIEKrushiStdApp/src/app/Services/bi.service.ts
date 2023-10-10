import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { orderSp } from '../Models/orderSp';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BIService {

  constructor(private httpClient:HttpClient) { }



  getOrdersFromStoreProcedure(todaysDate :string,storeId: number): Observable<orderSp> {
    let url = ' http://localhost:5161/api/bi/orderscount/' + todaysDate+"/" + storeId;
    return this.httpClient.get<orderSp>(url);
  }
}
