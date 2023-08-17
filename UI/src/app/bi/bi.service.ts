import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BiService {

  constructor(private http:HttpClient) { }

  public getCountByMonth(year:number):Observable<any>{
    let url="http://localhost:5161/api/bi/count/month/" +year;
    return this.http.get<any>(url);
  }

  public getMonthlyOrders(year:number):Observable<any>{
    let url="http://localhost:5161/api/bi/weekly/" +year;
    return this.http.get<any>(url);
  } 
  public getTotalRevenue(year:number):Observable<any>{
    let url="http://localhost:5161/api/bi/totalrevenue/" +year;
    return this.http.get<any>(url);
  }

  public getYearlyOrders():Observable<any>{
    let url=" http://localhost:5161/api/bi/yearly";
    return this.http.get<any>(url);
  }

  public SmePerformanceByMonth(year:number):Observable<any>{
    let url="http://localhost:5161/api/bi/smereport/" +year;
    return this.http.get<any>(url);
  }
 
}
