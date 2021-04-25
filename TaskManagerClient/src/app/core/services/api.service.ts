import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(protected http: HttpClient) { }

  getAll(path: string, id?: number): Observable<any> {
    if (id) {
      return this.http.get(`${environment.apiUrl}${path}` + '/' + id);
    } else {
      return this.http.get(`${environment.apiUrl}${path}`);
    }
  }

  getOne(path: string, id?: number): Observable<any> {
    return this.http.get(`${environment.apiUrl}${path}` + '/' + id);
  }

  create(path: string, resource: any, options?: any): Observable<any> {
    return this.http.post(`${environment.apiUrl}${path}`, resource).pipe(map(res => res));
  }

  delete(path: string, id?: number): Observable<any> {
    return this.http.delete(`${environment.apiUrl}${path}` + '/' + id);
  }
}

