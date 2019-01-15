import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  studentUrl : string = "http://localhost:51861/Student";

  constructor(private http: HttpClient) { }

  async getAllStudentExams(userId:string): Promise<any>  {
    return this.http.post(this.studentUrl +'?StudentId='+userId,userId).toPromise<any>();
  }
}
