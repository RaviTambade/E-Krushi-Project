import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from './category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService implements OnInit{

  constructor(private http:HttpClient) { }
  ngOnInit(): void {
  }

  public getAllCategories():Observable<any>{
    let url = "http://localhost:5214/category/getall";
    return this.http.get<any>(url);
  }

  public getCategoryDetails(categoryId:number):Observable<any>{
    let url = "http://localhost:5214/category/getcategory/"+categoryId;
    return this.http.get<any>(url);
  }

  public deleteCategory(categoryId:number):Observable<Category>{
    let url = "http://localhost:5214/category/deletecategory/"+ categoryId;
    return this.http.delete<Category>(url);
  }
}
