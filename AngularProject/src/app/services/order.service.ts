import { Order } from './../models/order.model';
import { ProductResponse } from './../models/productResponse.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  baseUrl: string = environment.baseUrl;

  constructor(private httpClient: HttpClient) {}

  getOrders(): Observable<ProductResponse<Order>> {
    return this.httpClient.get<ProductResponse<Order>>(
      this.baseUrl + 'Orders/getallorders'
    );
  }
}
