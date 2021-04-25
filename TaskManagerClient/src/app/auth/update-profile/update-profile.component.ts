import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/core/services/auth.service';
import { UserService } from 'src/app/core/services/user.service';
import { UserProfile } from 'src/app/shared/models/user-profile';
import { User } from 'src/app/shared/models/user';

@Component({
  selector: 'app-update-profile',
  templateUrl: './update-profile.component.html',
  styleUrls: ['./update-profile.component.css']
})
export class UpdateProfileComponent implements OnInit, OnDestroy {

  userUpdate: UserProfile = {
    id: 0,
    email: '',
    fullname: '',
    mobileno: ''
  }
  invalidUpdate: boolean = false;
  updateSucess: boolean = false;
  authSubscription: Subscription | undefined

  constructor(private authService: AuthService,
    private route: ActivatedRoute) {
  }
  ngOnDestroy() {
    this.authSubscription?.unsubscribe();
  }

  ngOnInit() {
    this.authService.populateUserInfo();
    this.authSubscription = this.authService.currentUser.subscribe(
      currentUser => {
        console.log(currentUser);
        this.userUpdate.id = currentUser.id;
        this.userUpdate.email = currentUser.email;
        this.userUpdate.fullname = currentUser.fullname;
        this.userUpdate.mobileno = currentUser.mobileno;
      }
    )
    console.log(this.userUpdate);
  }

  update() {
    this.authService.updateProfile(this.userUpdate).subscribe(
      (response) => {
        this.updateSucess = true;
      },
      (error) => {
        this.invalidUpdate = true;
      }
    )
  }
}
