import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Credential } from './Credential';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http:HttpClient) { }

  register(credential:Credential):Observable<boolean>{

    let url="http://localhost:5077/api/authentication/register";
    return this.http.post<any>(url,credential);
  }

  validate(credential: Credential): Observable<any> {
    let url = "http://localhost:5077/api/authentication/signin";
    return this.http.post<any>(url, credential);
  }


}
