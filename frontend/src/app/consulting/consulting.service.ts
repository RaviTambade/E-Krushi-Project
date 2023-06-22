import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConsultingService {

  constructor(private http:HttpClient) { }

  public getAllQuestions():Observable<any>{
    let url="http://localhost:5279/api/consulting/questions";
    return this.http.get<any>(url);
  }

  public getQuestion(id:number):Observable<any>{
    let url="localhost:5279/api/consulting/questions/" +id;
    return this.http.get<any>(url);
  }
}
