import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

@Injectable({ 
  providedIn: 'root' 
})

export class AuthService {

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  private baseUrl = 'https://localhost:5001/api/home'; // Adjust as needed
  private jwtHelper = new JwtHelperService();

  constructor(private http: HttpClient, private router: Router) {}

  login(credentials: any, password: any) {
    return this.http.post(`${this.baseUrl}/login`, credentials);
  }

  register(data: any) {
    return this.http.post(`${this.baseUrl}/register`, data);
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

  isAuthenticated() {
    const token = localStorage.getItem('token');
    return token && !this.jwtHelper.isTokenExpired(token);
  }

  getUserRole(): string {
    const token = localStorage.getItem('token');
    if (!token) return '';
    const decodedToken = this.jwtHelper.decodeToken(token);
    return decodedToken?.role || '';
  }


  getCurrentUser(): any {
    const token = this.getToken();
    if (!token) return null;

    const payload = JSON.parse(atob(token.split('.')[1]));
    return {
      email: payload.email,
      role: payload.role,
      name: payload.name
    };
  }


  isLoggedIn(): boolean {
    return !!this.getToken();
  }
}