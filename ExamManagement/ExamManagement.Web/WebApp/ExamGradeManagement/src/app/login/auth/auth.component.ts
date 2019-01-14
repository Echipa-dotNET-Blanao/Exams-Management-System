import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../services/login.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss'],
  providers : [LoginService]
})
export class AuthComponent implements OnInit {

  constructor(private loginService : LoginService) { }

  ngOnInit() {
  }

  makePostRequest(id : string, password : string) {
    console.log(this.loginService.makeLogin(id, password));
    this.loginService.makeLogin(id, password);
  }
}
