import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '@models/user';
import { Address } from 'membership-lib/lib/address';

@Injectable({
  providedIn: 'root',
})
export class MembershipService {
  constructor(private httpClient: HttpClient) {}


  getUser(id: number): Observable<User> {
    let url = `http://localhost:5142/api/users/${id}`;
    return this.httpClient.get<User>(url);
  }

  updateUser(id: number, user: User): Observable<any> {
    let url = `http://localhost:5142/api/users/${id}`;
    return this.httpClient.put<any>(url, user);
  }
  uploadFile(filename: string, formData: FormData): Observable<any> {
    let url = `http://localhost:5142/api/files/fileupload/${filename}`;
    return this.httpClient.post<any>(url, formData, {
      reportProgress: true,
      observe: 'events',
    });
  }

  addAddress(address: Address): Observable<boolean> {
    let url = `http://localhost:5142/api/addresses`;
    return this.httpClient.post<boolean>(url, address);
  }

  updateAddress(addressId: number, address: Address): Observable<boolean> {
    let url = `http://localhost:5142/api/addresses/${addressId}`;
    return this.httpClient.put<boolean>(url, address);
  }
}
