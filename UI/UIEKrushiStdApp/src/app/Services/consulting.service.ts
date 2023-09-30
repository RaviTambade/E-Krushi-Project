import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Question } from '../Models/question';
import { Observable } from 'rxjs';
import { QuestionAnswer } from '../Models/questionanswer';
import { Questioncategory } from '../Models/Questioncategory';

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

  getUser(userid:string): Observable<any> {
    let url = 'http://localhost:5102/api/users/name/'+userid;
    return this.httpClient.get<any>(url);
  }

  getCategorywiseQuestions(categoryid:number): Observable<Question[]> {
    let url = 'http://localhost:5279/api/consulting/Questions/Catagory/'+categoryid;
    return this.httpClient.get<Question[]>(url);
  }
}

