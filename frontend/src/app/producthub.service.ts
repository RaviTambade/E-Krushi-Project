import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProducthubService {

  constructor(private http : HttpClient) { }
  private subject = new Subject<any>();
  public getAllProducts():Observable<any>{
    let url = "http://localhost:5214/product/getallproducts";
    return this.http.get<any>(url);
  }
  sendProduct(data:any){
    let product = data.selectedProduct;
    console.log("Service is called");
    console.log(product);
  }
}
