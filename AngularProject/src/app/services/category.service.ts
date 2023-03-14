import { Category } from './../models/category.model';
import { environment } from './../../environments/environment';
import { ProductResponse } from './../models/productResponse.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  baseUrl: string = environment.baseUrl;
  public activeCategory$: BehaviorSubject<Category> =
    new BehaviorSubject<Category>({
      categoryId: 0,
      categoryName: '',
      description: '',
      picture: '',
    });

  setActiveCategory(category: Category) {
    this.activeCategory$.next(category);
  }

  constructor(private httpClient: HttpClient) {}

  getCategories(): Observable<ProductResponse<Category>> {
    return this.httpClient.get<ProductResponse<Category>>(
      this.baseUrl + 'Categories/getallcategories'
    );
  }
}
