import { HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtStorageService } from './jwt-storage.service';

@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor {

  constructor(private jwtServce: JwtStorageService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    interface HeadersConfig {
      [key: string]: string;
    }
    const headersConfig: HeadersConfig = {
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    }
    const token = this.jwtServce.getToken();
    if (token) {
      headersConfig['Authorization'] = `Bearer ${token}`;
      const authReq = req.clone({ setHeaders: headersConfig });
      return next.handle(authReq);
    }
    return next.handle(req);
  }
}
