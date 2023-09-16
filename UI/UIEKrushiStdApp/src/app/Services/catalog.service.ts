import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../Models/category';
import { Product } from '../Models/product';

@Injectable({
  providedIn: 'root',
})
export class CatalogService {
  constructor(private httpClient: HttpClient) {}

  getCategories(): Observable<Category[]> {
    let url = 'http://localhost:5288/api/categories';
    return this.httpClient.get<Category[]>(url);
  }
  getProducts(): Observable<Product[]> {
    let url = 'http://localhost:5288/api/products';
    return this.httpClient.get<Product[]>(url);
  }
  getProductsByCategory(categoryId:string): Observable<Product[]> {
    let url = 'http://localhost:5288/api/products/category/'+categoryId;
    return this.httpClient.get<Product[]>(url);
  }
  getProductPriceBySize(productId: number, size: string): Observable<number> {
    let url =
      'http://localhost:5288/api/Products/price/' + productId + '/' + size;
    return this.httpClient.get<number>(url);
  }
}
