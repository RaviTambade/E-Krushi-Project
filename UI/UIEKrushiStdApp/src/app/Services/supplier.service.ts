import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class SupplierService {
  private apiurl: string = environment.suppliersServiceUrl;

  constructor(private httpClient: HttpClient) {}

  getSupplierId(userId: number): Observable<number> {
    let url = `${this.apiurl}/id/${userId}`;
    return this.httpClient.get<number>(url);
  }

  getCorporateIdOfSupplier(supplierId: number): Observable<number> {
    let url = `${this.apiurl}/corporate/${supplierId}`;
    return this.httpClient.get<number>(url);
  }
}
