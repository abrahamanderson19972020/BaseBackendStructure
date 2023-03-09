import { ProductResponse } from './../models/productResponse.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { Employee } from '../models/employee.model';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  baseUrl: string = environment.baseUrl;

  constructor(private httpService: HttpClient) {}
  
  getEmployees(): Observable<ProductResponse<Employee>> {
    return this.httpService.get<ProductResponse<Employee>>(this.baseUrl + 'Employees/getallemployees');
  }
}
