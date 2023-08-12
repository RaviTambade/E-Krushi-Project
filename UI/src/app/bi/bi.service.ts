import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BiService {

  constructor(private http:HttpClient) { }

  public getTotalRevenue(year:number):Observable<any>{
    let url="http://localhost:5161/api/bi/totalrevenue/" +year;
    return this.http.get<any>(url);
  }
}
