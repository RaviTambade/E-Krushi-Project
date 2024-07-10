import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PaymentTransferDetails } from '@models/PaymentTransferDetails';
import { Observable } from 'rxjs';

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
