import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BankAccount } from '../Models/bankAccount';
import { PaymentTransferDetails } from '../Models/PaymentTransferDetails';

@Injectable({
  providedIn: 'root'
})
export class BankingService {
  constructor(private httpClient: HttpClient) {}

  getAccount(accountnumber: string): Observable<BankAccount> {
    let url = "http://localhost:5053/api/accounts/"+accountnumber;
    return this.httpClient.get<BankAccount>(url);
  }
  
  fundTransfer(payment: PaymentTransferDetails): Observable<number> {
    let url = "http://localhost:5001/api/fundstransfer";
    return this.httpClient.post<number>(url, payment);
  }

}
