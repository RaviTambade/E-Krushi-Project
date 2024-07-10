import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../product/product';

@Injectable({
  providedIn: 'root'
})
export class DefaultService {

  constructor(private http:HttpClient) { }


  public getAllProducts():Observable<Product>{
    let url = "http://localhost:5137/api/products";
    return this.http.get<any>(url);
  }
}
