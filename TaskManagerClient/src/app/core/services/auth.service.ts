import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Login } from 'src/app/shared/models/login';
import { User } from 'src/app/shared/models/user';
import { ApiService } from './api.service';
import { map } from 'rxjs/operators';
import { JwtStorageService } from './jwt-storage.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Register } from 'src/app/shared/models/register';
import { UserProfile } from 'src/app/shared/models/user-profile';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private user!: User;
  private currentUserSubject = new BehaviorSubject<User>({} as User);
  public currentUser = this.currentUserSubject.asObservable();

  private isAuthenticatedSubject = new BehaviorSubject<boolean>(false);
  public isAuthenticated: Observable<boolean> = this.isAuthenticatedSubject.asObservable();

  constructor(private apiService: ApiService, private jwtStorageService: JwtStorageService) { }

  register(userRegister: Register): Observable<any> {
    return this.apiService.create('/account/register', userRegister);
  }

  updateProfile(profileUpdate: UserProfile) {
    return this.apiService.create('/account/edit-profile', profileUpdate);
  }

  login(userLogin: Login): Observable<boolean> {
    const res = this.apiService.create('/account/login', userLogin)
      .pipe(map(response => {
        if (response) {
          this.jwtStorageService.saveToken(response.token);
          this.populateUserInfo();
          return true;
        }
        return false;
      }));
    return res;
  }

  logout() {
    this.jwtStorageService.destroyToken();
    this.currentUserSubject.next({} as User);
  }

  private decodedToken(): User {
    const token = this.jwtStorageService.getToken();
    if (!token || new JwtHelperService().isTokenExpired(token)) {
      this.logout();
      return {} as User;
    }
    const decodedToken = new JwtHelperService().decodeToken(token);
    this.user = decodedToken;
    return this.user;
  }

  populateUserInfo() {
    const token = this.jwtStorageService.getToken();
    if (token) {
      const decodedToken = this.decodedToken();
      this.currentUserSubject.next(decodedToken);
      this.isAuthenticatedSubject.next(true);
    }
  }
}
