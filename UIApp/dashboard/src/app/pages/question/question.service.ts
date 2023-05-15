import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QuestionService {

  constructor(private http:HttpClient) { }

  public getAllQuestions():Observable<any>{
    let url = "http://localhost:5241/questions/getallquestions";
    return this.http.get<any>(url);
}
public getQuestion(questionId:number):Observable<any>{
  let url = "http://localhost:5241/questions/getbyid/"+ questionId;
  return this.http.get<any>(url);
}
  
public deleteQuestion(questionId:number):Observable<any>{
  let url = "http://localhost:5241/questions/deletequestion/"+ questionId;
  return this.http.delete<any>(url);
}
}
