import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class AgridoctorService {

  constructor(private http:HttpClient) { }
  
  public getAllAgriDoctors():Observable<any>{
    let url = "http://localhost:5241/AgriDoctors/GetAllAgriDoctor";
    return this.http.get<any>(url);
  }

  // public getAgriDoctorDetails(agridoctorId:number):Observable<any>{
  //   let url = "http://localhost:5241/AgriDoctors/GetAgriDoctor"+ agridoctorId;
  //   return this.http.get<any>(url);
  // }

}
