import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PaymentTransferDetails } from '../Models/PaymentTransferDetails';

@Injectable({
  providedIn: 'root'
})
export class PaymentGatewayService {

  constructor(private httpClient: HttpClient) {}

  fundTransfer(payment: PaymentTransferDetails): Observable<number> {
    let url = 'http://localhost:5001/api/fundstransfer';
    return this.httpClient.post<number>(url, payment);
  }
}
