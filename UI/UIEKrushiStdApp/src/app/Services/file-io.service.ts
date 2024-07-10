import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FileIOService {
private fileIOServiceUrl=environment.fileIOServiceUrl;
  constructor(private httpClient: HttpClient) {}

  uploadFile(filename:string,formData:FormData): Observable<any> {
    let url = `${this.fileIOServiceUrl}/fileupload/${filename}`;
    return this.httpClient.post<any>(url, formData, {
      reportProgress: true,
      observe: 'events',
    });
  }
}
