import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { LocalStorageKeys } from '@enums/local-storage-keys';
import { UpdatePassword } from '@models/update-password';
import { Credential } from '@models/credential';
import { Observable } from 'rxjs';
import { TokenClaims } from '@enums/tokenclaims';
import { environment } from '@environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  constructor(
    private httpClient: HttpClient,
    private jwtHelper: JwtHelperService
  ) {}

  private authServiceurl: string = environment.authServiceUrl;
  signIn(credential: Credential): Observable<any> {
    let url =`${this.authServiceurl}/signin`;
    return this.httpClient.post<any>(url, credential);
  }

  updatePassword(credential: UpdatePassword): Observable<boolean> {
    let url =`${this.authServiceurl}/update/password`;
    const jwt = localStorage.getItem("jwt");
    return this.httpClient.put<any>(url, credential,{ headers: { authorization: `Bearer ${jwt}`  } });
  }

  // updateContact(credential: UpdateContact): Observable<boolean> {
  //   let url =`${this.authServiceurl}/update/contactnumber`;
  //   return this.httpClient.put<any>(url, credential);
  // }

  getClaimFromToken(claim: TokenClaims) {
    let token = localStorage.getItem(LocalStorageKeys.jwt);
    if (token) {
      const decodedToken = this.jwtHelper.decodeToken(token);
      console.log(decodedToken[claim]);
      return decodedToken[claim];
    }
    return null;
  }

  getRolesFromToken(): string[] {
    const token = localStorage.getItem(LocalStorageKeys.jwt);
    if (token) {
      const decodedToken = this.jwtHelper.decodeToken(token);
      const roles = decodedToken.roles;

      if (Array.isArray(roles)) {
        return roles;
      } else if (typeof roles === 'string') {
        return [roles];
      }
    }
    return [];
  }
}
