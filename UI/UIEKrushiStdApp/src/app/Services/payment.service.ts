import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '@environments/environment';
import { Payment } from '@models/Payment';
import { PaymentAddModel } from '@models/PaymentAddModel';
import { PaymentDetails } from '@models/paymentDetails';

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
