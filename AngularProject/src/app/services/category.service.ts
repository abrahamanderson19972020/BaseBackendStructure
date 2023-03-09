import { environment } from './../../environments/environment';
import { ProductResponse } from './../models/productResponse.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from '../models/category.model';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  baseUrl: string = environment.baseUrl;

  constructor(private httpClient: HttpClient) {}
  
  getCategories(): Observable<ProductResponse<Category>> {
    return this.httpClient.get<ProductResponse<Category>>(
      this.baseUrl + 'Categories/getallcategories'
    );
  }
}
