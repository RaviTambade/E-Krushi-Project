import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Item } from './items';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http:HttpClient) { }

  public getAllProducts():Observable<any>{
    let url = "http://localhost:5137/api/products";
    return this.http.get<any>(url);
  }

  public getById(id:any):Observable<any>{
    localStorage.setItem('id',id);
    let url = "http://localhost:5137/api/products/product/"+ id;
    return this.http.get<any>(url);
    
  }


  public addToCart(item:Item):Observable<any>{
    let url="http://localhost:5282/api/cart/addtocart";
    return this.http.post<any>(url,item);
  }
}
