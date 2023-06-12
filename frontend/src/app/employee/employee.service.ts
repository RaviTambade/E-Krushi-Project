import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http:HttpClient) { }

  public getAllProducts():Observable<any>{
    let url = "http://localhost:5137/api/products";
    return this.http.get<any>(url);
  }





}
