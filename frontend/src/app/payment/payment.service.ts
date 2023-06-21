import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from './order';
import { CreditCard } from './creditcard';
import { DebitCard } from './debitcard';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  constructor(private http:HttpClient) { }
  

  public addCreditCard(card:CreditCard):Observable<any>{
    let url ="http://localhost:5181/api/creditcards/creditcard";
    return this.http.post<CreditCard>(url,card);
    }

    public addDebitCard(card:DebitCard):Observable<any>{
      let url ="http://localhost:5181/api/debitcard";
      return this.http.post<CreditCard>(url,card);
      }

    
}
