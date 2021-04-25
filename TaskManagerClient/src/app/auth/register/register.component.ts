import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';
import { Register } from 'src/app/shared/models/register';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  userRegister: Register = {
    email: '',
    password: '',
    fullname: '',
    mobileno: ''
  }
  invalidRegister: boolean = false;
  registerSucess: boolean = false;

  constructor(private authService: AuthService,
    private router: Router) { }

  ngOnInit(): void {
  }

  register() {
    this.authService.register(this.userRegister).subscribe(
      (response) => {
        this.registerSucess = true;
        setTimeout(() => {
          this.router.navigate(['login']);
        }, 2000);
      },
      (error) => {
        this.invalidRegister = true;
      }
    )
  }

}
