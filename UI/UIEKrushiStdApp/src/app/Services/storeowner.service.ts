import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { orderSp } from '../Models/orderSp';

@Injectable({
  providedIn: 'root'
})
export class StoreownerService {

  constructor(private httpClient:HttpClient) { }



  getOrdersFromStoreProcedure(todaysDate :Date,storeId: number): Observable<orderSp> {
    let url = 'http://localhost:5226/api/stores/user/' + todaysDate+"/" + storeId;
    return this.httpClient.get<orderSp>(url);
  }
}
