import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  studentUrl : string = "http://localhost:51861/StudentAuth";

  constructor(private http: HttpClient) { }

  async makeLogin(login: string, pass: string): Promise<any>  {
    const body = {id: login, password: pass};
    return this.http.post(this.studentUrl, body).toPromise<any>();
  }
}
