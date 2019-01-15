import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class LoginService {

  loginUrl : string = "http://localhost:51861/StudentAuth";

  constructor(private http: HttpClient) { }

  async getUserDetails(login: string, pass: string): Promise<any>  {
    const body = {id: login, password: pass};
    return this.http.post(this.loginUrl, body).toPromise<any>();
 } 
}
