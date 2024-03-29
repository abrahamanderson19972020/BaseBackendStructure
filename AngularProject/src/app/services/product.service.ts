import { GeneralResponse } from './../models/generalRespone.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../models/product.model';
import { environment } from '../../environments/environment.development';
import { ProductResponse } from '../models/productResponse.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  baseUrl: string = environment.baseUrl;

  constructor(private httpClient: HttpClient) {}

  getProducts(): Observable<ProductResponse<Product>> {
    return this.httpClient.get<ProductResponse<Product>>(
      this.baseUrl + 'Products/getallproducts'
    );
  }

  getProductsByCategory(
    categoryId: number
  ): Observable<ProductResponse<Product>> {
    return this.httpClient.get<ProductResponse<Product>>(
      this.baseUrl + 'Products/productbycategory?categoryId=' + categoryId
    );
  }

  addProduct(product: Product): Observable<GeneralResponse> {
    return this.httpClient.post<GeneralResponse>(
      this.baseUrl + 'Products/add',
      product
    );
  }
}
