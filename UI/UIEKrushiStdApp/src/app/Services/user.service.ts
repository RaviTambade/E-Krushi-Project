import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { NameId } from '../Models/nameId';
import { Address } from '../Models/address';
import { AddressInfo } from '../Models/addressinfo';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  public newaddressSubject = new Subject<void>();
  public reloadnavbar = new Subject<void>();

  constructor(private httpClient: HttpClient) {}

  getUserByContact(contactNumber: string): Observable<NameId> {
    let url = 'http://localhost:5102/api/users/username/' + contactNumber;
    return this.httpClient.get<NameId>(url);
  }

  getUserRole(userId: number): Observable<string[]> {
    let url = 'http://localhost:6031/api/userroles/roles/' + userId;
    return this.httpClient.get<string[]>(url);
  }

  addAddress(address: Address): Observable<boolean> {
    let url = 'http://localhost:5102/api/addresses';
    return this.httpClient.post<boolean>(url, address);
  }

  getAddress(userId: number): Observable<AddressInfo[]> {
    let url = 'http://localhost:5102/api/addresses/' + userId;
    return this.httpClient.get<AddressInfo[]>(url);
  }

  getAddressById(addressId: number): Observable<AddressInfo> {
    let url = 'http://localhost:5102/api/addresses/details/' + addressId;
    return this.httpClient.get<AddressInfo>(url);
  }

  getaddressInfoByIdString(addressIdString:string): Observable<AddressInfo[]> {
    let url = 'http://localhost:5102/api/addresses/info/' + addressIdString;
    return this.httpClient.get<AddressInfo[]>(url);
  }

}
