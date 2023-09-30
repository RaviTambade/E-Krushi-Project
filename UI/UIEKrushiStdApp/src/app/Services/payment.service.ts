import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PaymentDetails } from '../Models/paymentDetails';
import { Observable } from 'rxjs';
import { Payment } from '../Models/Payment';
import { PaymentAddModel } from '../Models/PaymentAddModel';

@Injectable({
  providedIn: 'root',
})
export class PaymentService {
  constructor(private httpClient: HttpClient) {}

  getPaymentDetails(orderId: number): Observable<PaymentDetails> {
    let url = 'http://localhost:5015/paymentdetails/' + orderId;
    return this.httpClient.get<PaymentDetails>(url);
  }

  getPayments(customerId: number): Observable<Payment[]> {
    let url = 'http://localhost:5015/payment/' + customerId;
    return this.httpClient.get<Payment[]>(url);
  }

  addPayment(payment: PaymentAddModel): Observable<boolean> {
    let url = 'http://localhost:5015/payment/';
    return this.httpClient.post<boolean>(url, payment);
  }
}