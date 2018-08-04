import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SignUpModel } from './models/signup.model';
import { SignInModel } from './models/signin.model';

const loginUrl = 'http://localhost:5000/auth/login';
const registerUrl = 'http://localhost:5000/auth/signup';

@Injectable()
export class AuthService {
  constructor(private http : HttpClient) {  }

  register(body : SignUpModel) {
    return this.http.post(registerUrl, body);
  }

  login(body : SignInModel) {
    return this.http.post(loginUrl, body);
  }

  logout() {
    localStorage.clear();
  }

  isAuthenticated() : boolean {
    return localStorage.getItem('currentUser') !== null;
  }
}