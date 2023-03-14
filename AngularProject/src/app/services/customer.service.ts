import { Customer } from './../models/customer.model';
import { ProductResponse } from './../models/productResponse.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  baseUrl: string = environment.baseUrl;

  constructor(private httpClient: HttpClient) {}

  getCustomers(): Observable<ProductResponse<Customer>> {
    return this.httpClient.get<ProductResponse<Customer>>(
      this.baseUrl + 'Customers/getallcustomers'
    );
  }
}
