import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Question } from '../Models/question';
import { Observable } from 'rxjs';
import { QuestionAnswer } from '../Models/questionanswer';

@Injectable({
  providedIn: 'root'
})
export class ConsultingService {

  constructor(private httpClient: HttpClient) { }

  getQuestions(): Observable<Question[]> {
    let url = 'http://localhost:5279/api/consulting';
    return this.httpClient.get<Question[]>(url);
  }


  getAnswers(id:number): Observable<QuestionAnswer[]> {
    let url = 'http://localhost:5279/api/consulting/answers/'+id;
    return this.httpClient.get<QuestionAnswer[]>(url);
  }
}

