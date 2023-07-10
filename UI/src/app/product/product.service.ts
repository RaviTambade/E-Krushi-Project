import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }

  public newProduct(product:Product):Observable<any>{
    let url ="http://localhost:5137/api/products";
    return this.http.post<Product>(url,product);
    }

}
