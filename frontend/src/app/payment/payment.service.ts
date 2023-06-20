import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from './order';
import { CreditCard } from './creditcard';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  constructor(private http:HttpClient) { }
  

  public addCard(card:CreditCard):Observable<any>{
    let url ="http://localhost:5181/api/creditcards/creditcard";
    return this.http.post<CreditCard>(url,card);
    }
}
