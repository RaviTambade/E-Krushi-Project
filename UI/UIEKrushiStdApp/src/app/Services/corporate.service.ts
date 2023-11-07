import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NameId } from '@models/nameId';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class CorporateService {
  constructor(private httpClient: HttpClient) {}

  getCorporateName(id: number): Observable<any[]> {
    let url = 'http://localhost:5041/api/corporates/names/' +id;
    return this.httpClient.get<any>(url);
  }
}
