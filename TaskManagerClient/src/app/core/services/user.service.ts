import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private apiService: ApiService) { }

  getUsers(): Observable<any[]> {
    return this.apiService.getAll('/users');
  }

  getUserById(id: number): Observable<any> {
    return this.apiService.getOne('/users', id);
  }
}
