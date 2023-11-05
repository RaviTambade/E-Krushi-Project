import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { NameId } from '../Models/nameId';
import { Address } from '../Models/address';
import { AddressInfo } from '../Models/addressinfo';
import { User } from '../Models/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private userApiurl: string = environment.usersServiceUrl;
  private addressApiurl: string = environment.userAddressServiceUrl;

  public newaddressSubject = new Subject<void>();
  public reloadnavbar = new Subject<void>();

  constructor(private httpClient: HttpClient) {}

  getUserByContact(contactNumber: string): Observable<NameId> {
    let url = `${this.userApiurl}/username/${contactNumber}`;
    return this.httpClient.get<NameId>(url);
  }
  getUserNamesWithId(userId: string): Observable<NameId[]> {
    let url = `${this.userApiurl}/name/${userId}`;
    return this.httpClient.get<NameId[]>(url);
  }

  addUser(user: User): Observable<any> {
    let url = `${this.userApiurl}`;
    return this.httpClient.post<any>(url, user);
  }

  updateUser(id: number, user: User): Observable<any> {
    let url = `${this.userApiurl}/${id}`;
    return this.httpClient.put<any>(url, user);
  }

  getUser(id: number): Observable<User> {
    let url = `${this.userApiurl}/${id}`;
    return this.httpClient.get<User>(url);
  }

  addAddress(address: Address): Observable<boolean> {
    let url = `${this.addressApiurl}`;
    return this.httpClient.post<boolean>(url, address);
  }

  getAddress(userId: number): Observable<AddressInfo[]> {
    let url = `${this.addressApiurl}/${userId}`;
    return this.httpClient.get<AddressInfo[]>(url);
  }

  getAddressById(addressId: number): Observable<AddressInfo> {
    let url = `${this.addressApiurl}/details/${addressId}`;
    return this.httpClient.get<AddressInfo>(url);
  }

  getaddressInfoByIdString(addressIdString: string): Observable<AddressInfo[]> {
    let url = `${this.addressApiurl}/info/${addressIdString}`;
    return this.httpClient.get<AddressInfo[]>(url);
  }
}
