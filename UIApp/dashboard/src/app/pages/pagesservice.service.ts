import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class PagesserviceService {

  constructor(private http:HttpClient) { }

  public ValidateUser(form:any):Observable<any>{
    let url = "http://localhost:5150/users/validateuser";
    return this.http.post<any>(url,form);
  }

  public Register(user:User):Observable<any>{
    let url = "http://localhost:5150/users/register";
    return this.http.post<User>(url,user);
  }
}
