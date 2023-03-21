import { RegisterResponse } from './../models/registerResponse.model';
import { RegisterUser } from './../models/registerUser.model';
import { BehaviorSubject, Observable } from 'rxjs';
import { LoginResponse } from './../models/loginResponse.model';
import { ProductResponse } from './../models/productResponse.model';
import { LoginUser } from './../models/loginUser.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  baseUrl: string = environment.baseUrl;
  private isLoggedIn = new BehaviorSubject<boolean>(this.hasToken());

  constructor(private httpClient: HttpClient) {}

  login(loginUser: LoginUser): Observable<LoginResponse> {
    this.isLoggedIn.next(true);
    return this.httpClient.post<LoginResponse>(
      this.baseUrl + 'Auths/login',
      loginUser
    );
  }

  register(registerUser: RegisterUser): Observable<RegisterResponse> {
    return this.httpClient.post<RegisterResponse>(
      this.baseUrl + 'Auths/register',
      registerUser
    );
  }
  isAuthenticated(): Observable<boolean> {
    return this.isLoggedIn.asObservable();
  }

  private hasToken() {
    return !!localStorage.getItem('token');
  }
  logout() {
    localStorage.removeItem('token');
    this.isLoggedIn.next(false);
  }
}
