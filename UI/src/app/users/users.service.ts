import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './user';
import { Location } from './location';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private http:HttpClient) { }

  public userProfile(userId:number):Observable<any>{
    let url="http://localhost:5102/api/users/userprofile/"+userId;
    return this.http.get<any>(url);
  }

  public editUserProfile(userId:any,user:User):Observable<any>{
    let url="http://localhost:5102/api/users/"+ userId;
    return this.http.put<any>(url,user);
  }

  public editLocationProfile(userId:any,location:Location):Observable<any>{
    let url="http://localhost:5102/api/locations/"+userId;
    return this.http.put<any>(url,location);
  }
}
