import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CrmService {

  constructor(private http:HttpClient)  { }
  
  
  
  public getAllCustomers():Observable<any>{
    let url = "http://localhost:5025/api/customer/getall";
    return this.http.get<any>(url);
  }
}







