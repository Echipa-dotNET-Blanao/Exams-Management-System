import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../services/login.service';
import { User } from '../../shared/models/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss'],
  providers : [LoginService]
})
export class AuthComponent implements OnInit {

  loggedUser: User;

  constructor(private loginService: LoginService, private router: Router) { }

  ngOnInit() {
  }

  async makePostRequest(id: string, password: string) {
    this.loggedUser = await this.loginService.makeLogin(id, password);
    this.chekIfStudentOrProf(this.loggedUser);
  }

  chekIfStudentOrProf(user: User){
    if (user.email != 'fii.exam.manager@gmail.com'){
      user.isStudent = true;
      this.router.navigate(['/student-dashboard']);
    } else {
      user.isStudent = false;
      this.router.navigate(['/teacher-dashboard']);
    }
  }

}
