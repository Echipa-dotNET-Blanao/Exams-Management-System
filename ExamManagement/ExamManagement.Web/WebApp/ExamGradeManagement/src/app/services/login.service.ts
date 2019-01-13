import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  
  loginUrl : string = "localhost:51861/api/StudentAuth";

  constructor(private http: HttpClient) { }

  makeLogin(login: string, pass: string)  {
    const body = {user: login, password: pass};

    this.http.post(this.loginUrl, body)
    .subscribe(data => {
      console.log(body);
    });
 } 
}
