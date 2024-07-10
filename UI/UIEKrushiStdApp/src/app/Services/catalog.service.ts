import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@environments/environment';
import { Category } from '@models/category';
import { Product } from '@models/product';
import { ProductDescription } from '@models/ProductDescription';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root',
})
export class CatalogService {
  constructor(private httpClient: HttpClient) {}
  private productsApiurl: string = environment.catalogServiceProductUrl;
  private categoriesApiurl: string = environment.catalogServiceCategoriesUrl;

  getCategories(): Observable<Category[]> {
    let url = this.categoriesApiurl;
    return this.httpClient.get<Category[]>(url);
  }
  getProducts(): Observable<Product[]> {
    let url = this.productsApiurl;
    return this.httpClient.get<Product[]>(url);
  }
  getProductDetails(productId: number): Observable<ProductDescription> {
    let url = `${this.productsApiurl}/details/${productId}`;
    return this.httpClient.get<ProductDescription>(url);
  }
  getProductsByCategory(categoryId: string): Observable<Product[]> {
    let url = `${this.productsApiurl}/category/${categoryId}`;
    return this.httpClient.get<Product[]>(url);
  }
  getSimilarProducts(productId: number): Observable<Product[]> {
    let url = `${this.productsApiurl}/similar/${productId}`;
    return this.httpClient.get<Product[]>(url);
  }
  getSearchedProducts(searchString: string): Observable<Product[]> {
    let url = `${this.productsApiurl}/search/${searchString}`;
    return this.httpClient.get<Product[]>(url);
  }
  getProductPriceBySize(productId: number, size: string): Observable<number> {
    let url = `${this.productsApiurl}/price/${productId}/${size}`;
    return this.httpClient.get<number>(url);
  }

  getProductNameSuggestions(searchString: string): Observable<string[]> {
    let url =`${this.productsApiurl}/suggestions/names/${searchString}`;
    return this.httpClient.get<string[]>(url);
  }
}
