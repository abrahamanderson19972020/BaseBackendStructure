import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  baseUrl: string = environment.baseUrl;

  constructor() {}
}
