import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Product } from './product';

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

      public getCategories():Observable<any>{
        let url = "http://localhost:5137/api/categories";
        return this.http.get<any>(url);
      }
      
      public getProducts(category:string):Observable<any>{
        let url="http://localhost:5137/api/products/categoryname/"+ category;
        return this.http.get<any>(url);
      }

     public Delete(id:number):Observable<any>{
     let url="http://localhost:5137/api/products/"+ {id};
     return this.http.delete<any>(url);
    } 

    private subject = new Subject<any>();
    public getAllProducts():Observable<any>{
      let url = "http://localhost:5137/api/products";
      return this.http.get<any>(url);
    }
    sendProduct(data:any){
      let product = data.selectedProduct;
      console.log("Service is called");
      console.log(product);
  
    switch(product){
      case "oats":{
        let url = " http://localhost:5137/api/product/"+ product;
        this.http.get(url).subscribe((data) =>{
          console.log(data);
          this.subject.next({data,product});
        });
        break;
      }
      case "wheat":{
        let url = "http://localhost:5137/api/product/"+ product;
        this.http.get(url).subscribe((data) =>{
          console.log(data);
          this.subject.next({data,product});
        });
        break;
      }
      case "manure":{
        let url = "http://localhost:5137/api/product/"+ product;
        this.http.get(url).subscribe((data) =>{
          console.log(data);
          this.subject.next({data,product});
        });
        break;
      }
    }
  }
  
  getData(): Observable<any>{
    return this.subject.asObservable();
  }
  

}