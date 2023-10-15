import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from '../Models/Order';
import { NameId } from '../Models/nameId';

@Injectable({
  providedIn: 'root'
})
export class CorporateService {
  constructor(private httpClient: HttpClient) {}

  getCorporateName(id: number): Observable<NameId[]> {
    let url = 'http://localhost:5041/api/corporates/names/' +id;
    return this.httpClient.get<NameId[]>(url);
  }
}
