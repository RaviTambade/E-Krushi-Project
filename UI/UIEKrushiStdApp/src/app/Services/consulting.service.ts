import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Question } from '../Models/question';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConsultingService {

  constructor(private httpClient: HttpClient) { }

  getQuestions(): Observable<Question[]> {
    let url = 'http://localhost:5279/api/consulting';
    return this.httpClient.get<Question[]>(url);
  }
}
