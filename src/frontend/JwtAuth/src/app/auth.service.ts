import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Route, Router } from '@angular/router';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private BASE_URL: string = "http://localhost:5229";

  constructor(private httpClient: HttpClient, private router: Router) { }

  login = (username: string, password: string): Observable<boolean> => {
    const url = `${this.BASE_URL}/login`;
    const result = this.httpClient.post<string>(url, {
      username: username,
      password: password
    });

    result.subscribe(res => {
      this.setToken(res);
      this.router.navigate(["dashboard"]);
    });

    return result.pipe(map((res) => res != null && res != ''));
  }

  setToken(token: string) {
    localStorage.setItem("token", token);
  }

  isAuthenticate() {
    const token = localStorage.getItem("token");

    if (token && token != '')
      return true;

    return false;
  }

  hasRole(role: string) {
    if(!this.isAuthenticate())
      return false;

    const token = localStorage.getItem("token") ?? "";
    const decodedToken = this.decodeJwt(token);
    return decodedToken.role === role;
  }

  // Decode JWT token
  private decodeJwt(token: string): any {
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    return JSON.parse(window.atob(base64));
  }

  logout() {
    localStorage.removeItem("token");
    this.router.navigate(["/"]);
  }
}
