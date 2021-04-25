import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { User } from 'src/app/shared/models/user';
import { UserProfile } from 'src/app/shared/models/user-profile';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit, OnDestroy {

  currentUser: UserProfile = {
    id: 0,
    fullname: '',
    email: '',
    mobileno: ''
  }
  currentStatus: Observable<User> | undefined;

  authSubscription: Subscription | undefined;

  constructor(public authService: AuthService) { }


  ngOnDestroy(): void {
    this.authSubscription?.unsubscribe();
  }

  ngOnInit(): void {
    this.authService.populateUserInfo();
    this.currentStatus = this.authService.currentUser;
    this.authSubscription = this.currentStatus.subscribe(
      u => {
        this.currentUser.id = u.id;
        this.currentUser.fullname = u.fullname;
      }
    )
  }
  logout() {
    this.authService.logout();
  }

}
