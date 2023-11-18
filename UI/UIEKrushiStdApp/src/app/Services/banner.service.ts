import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BannerService {
  private bannerCards = [
    {
      imageUrl: '/assets/Pesticides.png',
    },
    {
      imageUrl: '/assets/antracolmain1.jpg',
    },
    {
      imageUrl: '/assets/tools.png',
    },
  ];

  constructor(private http:HttpClient) {}

  getAllBanners(): Observable<any> {
    return of(this.bannerCards);
  }
}
