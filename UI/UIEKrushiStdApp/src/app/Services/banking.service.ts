import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BankAccount } from '../Models/bankAccount';
import { PaymentTransferDetails } from '../Models/PaymentTransferDetails';
import { LocalStorageKeys } from '../Models/Enums/local-storage-keys';

@Injectable({
  providedIn: 'root',
})
export class BankingService {
  constructor(private httpClient: HttpClient) {}

  getAccount(accountnumber: string): Observable<BankAccount> {
    let url = 'http://localhost:5053/api/accounts/' + accountnumber;
    return this.httpClient.get<BankAccount>(url);
  }


  checkAccount(customerId:number): Observable<BankAccount> {
    var body = {
      usertype: 'person',
      DependencyId: customerId,
    };
    let url = 'http://localhost:5053/api/accounts/details/';
    return this.httpClient.post<BankAccount>(url, body);
  }
}
