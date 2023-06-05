import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './user';
import { Order } from './order';
import { Product } from './product/product';

@Injectable({
  providedIn: 'root'
})
export class PagesserviceService {

  constructor(private http:HttpClient) { }

  public ValidateUser(form:any):Observable<any>{
    let url = "http://localhost:5150/users/validateuser";
    return this.http.post<any>(url,form);
  }

  public Register(user:User):Observable<any>{
    let url = "http://localhost:5150/users/register";
    return this.http.post<User>(url,user);
  }

  // public TotalCount():Observable<any>{
  //   let url = "http://localhost:5057/orders/totalcount";
  //   return this.http.get<any>(url);
  // }
  
  public getAllProducts():Observable<any>{
    let url = "http://localhost:5214/product/getallproducts";
    return this.http.get<any>(url);
  }

  public getProduct(productId:number):Observable<Product>{
    let url = "http://localhost:5214/product/getproduct/"+ productId;
    return this.http.get<Product>(url);
  }
  
  


 }
