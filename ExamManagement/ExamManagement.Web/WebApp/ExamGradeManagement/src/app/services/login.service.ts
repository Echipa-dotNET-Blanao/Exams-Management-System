import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../shared/models/user';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  loginUrl : string = "http://localhost:51861/Auth";

  constructor(private http: HttpClient) { }

  async getUserDetails(login: string, pass: string): Promise<User>  {
    const body = {username: login, password: pass};
    return this.http.post(this.loginUrl, body).pipe(map((result: User) => {
      return result;
    })).toPromise();
 }

}
