import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private http:HttpClient) { }

  public userProfile(userId:number):Observable<any>{
    let url="http://localhost:5102/api/users/userprofile/"+userId;
    return this.http.get<any>(url);
  }




}
