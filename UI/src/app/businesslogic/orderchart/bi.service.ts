import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BiService {

  constructor(private http:HttpClient) { }

  public getCountByMonth(year:number):Observable<any>{
    let url="http://localhost:5057/api/orders/count/month/" +year;
    return this.http.get<any>(url);
  }
}
