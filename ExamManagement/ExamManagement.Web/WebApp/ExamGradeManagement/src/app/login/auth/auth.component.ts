import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../services/login.service';
import { User } from '../../shared/models/user';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss'],
  providers : [LoginService]
})
export class AuthComponent implements OnInit {
  
  loggedUser:User;

  constructor(private loginService: LoginService, private router: Router, private cookieService: CookieService) { }

  ngOnInit() {
  }

  async getLogin(id : string, password : string) {
    this.loggedUser = await this.loginService.getUserDetails(id, password);
    this.cookieService.set( 'Username', id );
    this.chekIfStudentOrProf(this.loggedUser);
  }

  chekIfStudentOrProf(user: User){
    if (user.isStudent){
      this.router.navigate(['/student-dashboard']);
    }
    else{
      this.router.navigate(['/teacher-dashboard']);
    }
  }

}
