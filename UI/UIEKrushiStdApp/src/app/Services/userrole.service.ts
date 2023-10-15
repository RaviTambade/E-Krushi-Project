import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserRoleService {
  constructor(private httpClient: HttpClient) {}

  getUserRole(userId: number): Observable<string[]> {
    let url = 'http://localhost:6031/api/userroles/roles/' + userId;
    return this.httpClient.get<string[]>(url);
  }
}
