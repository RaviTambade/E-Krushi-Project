import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { NameId } from '../Models/nameId';
import { Address } from '../Models/address';
import { AddressInfo } from '../Models/addressinfo';
import { User } from '../Models/user';

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
  getUserNamesWithId(userId: string): Observable<NameId[]> {
    let url = "http://localhost:5102/api/users/name/" + userId;
    return this.httpClient.get<NameId[]>(url)
  }


  addUser(user: User): Observable<any> {
    let url = "http://localhost:5102/api/users"
    return this.httpClient.post<any>(url, user)
  }

  updateUser(id: number, user: User): Observable<any> {
    let url = "http://localhost:5102/api/users/" + id
    return this.httpClient.put<any>(url, user)
  }

  getUser(id: number): Observable<User> {
    let url = "http://localhost:5102/api/users/" + id
    return this.httpClient.get<User>(url)
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
