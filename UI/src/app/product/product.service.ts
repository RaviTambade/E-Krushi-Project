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

  public getAllCategories():Observable<any>{
      let url = "http://localhost:5137/api/categories";
      return this.http.get<any>(url);
    }


    public getCountByMonth(year:number):Observable<any>{
      let url="http://localhost:5137/api/products/sale/" +year;
      return this.http.get<any>(url);
    }

      public getById(id:any):Observable<any>{
        let url = "http://localhost:5137/api/products/product/" +id;
        return this.http.get<any>(url);
      }

}