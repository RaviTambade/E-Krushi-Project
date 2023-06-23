import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CustomerQuestion } from './customerquestion';

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
    let url="http://localhost:5279/api/consulting/questions/" +id;
    return this.http.get<any>(url);
  }


  public insertCustomerQuestion(question:CustomerQuestion):Observable<any>{
    let url="http://localhost:5279/api/consulting/customerquestion";
    return this.http.post<any>(url,question);
  }

  public GetCustomerQuestionDetails(custId:any):Observable<any>{
    let url="http://localhost:5279/api/consulting/questionDetails/"+custId;
    return this.http.get<any>(url);
  }
}
