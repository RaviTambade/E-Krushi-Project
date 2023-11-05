import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PaymentDetails } from '../Models/paymentDetails';
import { Observable } from 'rxjs';
import { Payment } from '../Models/Payment';
import { PaymentAddModel } from '../Models/PaymentAddModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class PaymentService {
  private apiurl: string = environment.paymentsServiceUrl;

  constructor(private httpClient: HttpClient) {}

  getPaymentDetails(orderId: number): Observable<PaymentDetails> {
    let url = `${this.apiurl}/details/${orderId}`;
    return this.httpClient.get<PaymentDetails>(url);
  }

  getPayments(customerId: number): Observable<Payment[]> {
    let url = `${this.apiurl}/${customerId}`;
    return this.httpClient.get<Payment[]>(url);
  }

  addPayment(payment: PaymentAddModel): Observable<boolean> {
    let url = `${this.apiurl}`;
    return this.httpClient.post<boolean>(url, payment);
  }
}
