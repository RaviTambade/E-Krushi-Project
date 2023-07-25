import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from './order';
import { CreditCard } from './creditcard';
import { DebitCard } from './debitcard';
import { Billing } from './billing';

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

    public  fundTransfer(credential:any):Observable<any>{
        let url ="http://localhost:5041/fundstransfer";
        return this.http.post<any>(url,credential);
      }

    public addBill(bill:Billing):Observable<any>{
        let url ="http://localhost:5238/api/billing";
        return this.http.post<Billing>(url,bill);
      }

      public createOrder(id : number):Observable<any>{
        let url ="http://localhost:5282/api/cart/createOrder/"+id;
        return this.http.get<any>(url);
      }
}
