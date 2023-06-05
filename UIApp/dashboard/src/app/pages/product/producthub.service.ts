import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Product } from './product';

@Injectable({
  providedIn: 'root'
})
export class ProducthubService {

  constructor(private http : HttpClient) { }
  private subject = new Subject<any>();
  // public getAllProducts():Observable<any>{
  //   let url = "http://localhost:5214/product/getallproducts";
  //   return this.http.get<any>(url);
  // }

  public getByCategoryName(category:string):Observable<any>{
    let url = "http://localhost:5214/api/catalogs/categories/"+ category;
    return this.http.get<any>(url);
  }

  sendCategory(data:any){
    let category = data.selectedCategory;
    console.log("Service is called");
    console.log(category);

    switch(category){
      case "seeds":{
        let url = " http://localhost:5214/api/catalogs/products/category/"+ category;
        this.http.get(url).subscribe((data) =>{
          console.log(data);
          this.subject.next({data,category});
        });
        break;
      }
      case "agriculture equipments":{
        let url = " http://localhost:5214/api/catalogs/products/category/"+ category;
        this.http.get(url).subscribe((data) =>{
          console.log(data);
          this.subject.next({data,category});
        });
        break;
      }
      case "fertilizers":{
        let url = " http://localhost:5214/api/catalogs/products/category/"+ category;
        this.http.get(url).subscribe((data) =>{
          console.log(data);
          this.subject.next({data,category});
        });
        break;
      }
    }
  }

  getData(): Observable<any>{
    return this.subject.asObservable();
  }


  public insertProduct(product:Product):Observable<any>{
    let url ="http://localhost:5214/api/catalogs/insert/product";
    return this.http.post<Product>(url,product);  
  }
}




