import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { AuthService } from '../core/services/auth.service';
import { UserService } from '../core/services/user.service';
import { User } from '../shared/models/user';
import { UserProfile } from '../shared/models/user-profile';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, OnDestroy {

  public isCollapsed = false;

  users: User[] | undefined;
  currentUser: UserProfile = {
    id: 0,
    fullname: '',
    email: '',
    mobileno: ''
  }
  currentStatus: Observable<User> | undefined;

  authSubscription: Subscription | undefined;

  constructor(private userService: UserService,
    public authService: AuthService) {
  }
  ngOnDestroy(): void {
    this.authSubscription?.unsubscribe();
  }

  ngOnInit() {
    this.authService.populateUserInfo();
    this.currentStatus = this.authService.currentUser;
    this.authSubscription = this.currentStatus.subscribe(
      u => {
        this.currentUser.id = u.id;
        this.currentUser.fullname = u.fullname;
      }
    )
    this.getAllUsers();
    console.log(this.currentUser);
  }

  getAllUsers() {
    this.userService.getUsers().subscribe(
      u => {
        this.users = u;
      }
    )
  }
}
