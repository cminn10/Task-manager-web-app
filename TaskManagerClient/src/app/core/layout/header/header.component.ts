import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit, OnDestroy {

  isAuthenticated: boolean = false;
  authSubscription: Subscription | undefined;

  constructor(public authService: AuthService) { }


  ngOnDestroy(): void {
    this.authSubscription?.unsubscribe();
  }

  ngOnInit(): void {
    this.authService.populateUserInfo();
    this.authSubscription = this.authService.isAuthenticated.subscribe(
      isAuth => {
        this.isAuthenticated = isAuth;
        console.log(this.isAuthenticated);
      }
    )
  }
  logout() {
    this.authService.logout();
    this.isAuthenticated = true;
  }

}
