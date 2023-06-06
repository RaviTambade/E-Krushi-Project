import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import {HttpClient} from '@angular/common/http'
@Injectable({
  providedIn: 'root'
})
export class ProductHubServiceService {

 private subject = new Subject<any>();
constructor(private http : HttpClient) { }
  
  public getAllProducts():Observable<any>{
    let url = "http://localhost:5214/product/getallproducts";
    return this.http.get<any>(url);
  }

}
