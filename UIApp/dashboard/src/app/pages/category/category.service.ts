import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

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
}
