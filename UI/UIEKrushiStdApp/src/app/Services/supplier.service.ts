import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  constructor(private httpClient: HttpClient) {}

  getSupplierId(userId: number): Observable<number> {
    let url = 'http://localhost:5072/api/suppliers/id/' + userId;
    return this.httpClient.get<number>(url);
  }

  getCorporateIdOfSupplier(supplierId: number): Observable<number> {
    let url = 'http://localhost:5072/api/suppliers/corporate/' + supplierId;
    return this.httpClient.get<number>(url);
  }



}
