import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PaymentDetails } from '../Models/paymentDetails';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  constructor(private httpClient: HttpClient) { }


  getPaymentDetails(orderid:number):Observable<PaymentDetails>{
    let url = 'http://localhost:5015/paymentdetails/'+orderid;
    return this.httpClient.get<PaymentDetails>(url);
  }
}
