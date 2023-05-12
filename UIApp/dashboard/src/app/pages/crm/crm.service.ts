import { HttpClient } from '@angular/common/http';
import { Injectable, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from './customer';

@Injectable({
  providedIn: 'root'
})
export class CrmService {

  constructor(private http:HttpClient)  { }
  
  public getAllCustomers():Observable<any>{
    let url = "http://localhost:5025/api/customer/getall";
    return this.http.get<any>(url);
  }


  public getCustomer(custId:number):Observable<Customer>{
    let url = "http://localhost:5025/api/customer/getcustomer/"+ custId;
    return this.http.get<Customer>(url);
  }

  public insertCustomer(customer:Customer):Observable<any>{
    let url = "http://localhost:5025/api/customer/insertcustomer";
    return this.http.post<Customer>(url,customer);
  }

  public updateCustomer(customer:Customer):Observable<any>{
    let url = "http://localhost:5025/api/customer/updatecustomer";
    return this.http.put<Customer>(url,customer);
  }
  public deleteCustomer(custId:number):Observable<Customer>{
    let url = "http://localhost:5025/api/customer/delete/"+ custId;
    return this.http.delete<Customer>(url);
  }
}







