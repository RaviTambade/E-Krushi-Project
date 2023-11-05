import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BankAccount } from '../Models/bankAccount';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class BankingService {
  private apiurl: string = environment.bankingServiceUrl;
  constructor(private httpClient: HttpClient) {}

  getAccount(accountnumber: string): Observable<BankAccount> {
    let url = `${this.apiurl}/accountnumber`;
    return this.httpClient.get<BankAccount>(url);
  }

  checkAccount(customerId: number): Observable<BankAccount> {
    var body = {
      usertype: 'person',
      DependencyId: customerId,
    };
    let url = `${this.apiurl}/details`;
    return this.httpClient.post<BankAccount>(url, body);
  }
}
