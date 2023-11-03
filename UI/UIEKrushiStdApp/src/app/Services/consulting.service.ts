import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Question } from '../Models/question';
import { Observable } from 'rxjs';
import { QuestionAnswer } from '../Models/questionanswer';
import { Questioncategory } from '../Models/Questioncategory';
import { InsertQuestion } from '../Models/InsertQuestion';

@Injectable({
  providedIn: 'root'
})
export class ConsultingService {

  constructor(private httpClient: HttpClient) { }

  getQuestions(): Observable<Question[]> {
    let url = 'http://localhost:5279/api/consulting';
    return this.httpClient.get<Question[]>(url);
  }

  getAllCategories(): Observable<Questioncategory[]> {
    let url = 'http://localhost:5279/api/consulting/questioncatagories';
    return this.httpClient.get<Questioncategory[]>(url);
  }


  getAnswers(id:number): Observable<QuestionAnswer[]> {
    let url = 'http://localhost:5279/api/consulting/answers/'+id;
    return this.httpClient.get<QuestionAnswer[]>(url);
  }

  getReletedQuestions(id:number): Observable<Question[]> {
    let url = 'http://localhost:5279/api/consulting/reletedquestions/'+id;
    return this.httpClient.get<Question[]>(url);
  }
  public insertQuestion(question:InsertQuestion):Observable<any>{
    let url="http://localhost:5279/api/consulting/question";
    return this.httpClient.post<any>(url,question);
  }


  getCategorywiseQuestions(categoryid:number): Observable<Question[]> {
    let url = 'http://localhost:5279/api/consulting/Questions/Catagory/'+categoryid;
    return this.httpClient.get<Question[]>(url);
  }

  getSubjectMatterExpertsSolvedQuestions( smeid:number):Observable<any[]>{
    let url ='http://localhost:5279/api/consulting/smequestions/'+smeid;
    return this.httpClient.get<any[]>(url);
  }

  getUnSolvedQuestions( smeid:number):Observable<any[]>{
    let url ='http://localhost:5161/api/consulting/notansweredquestions/'+smeid;
    return this.httpClient.get<any[]>(url);
  }
}

