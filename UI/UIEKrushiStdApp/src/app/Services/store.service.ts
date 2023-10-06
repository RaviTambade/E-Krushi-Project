import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class StoreService {
  constructor(private httpClient: HttpClient) {}

  getStoreUserId(storeId: number): Observable<number> {
    let url = 'http://localhost:5226/api/stores/user/' + storeId;
    return this.httpClient.get<number>(url);
  }
}
