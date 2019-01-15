import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  studentUrl : string = "https://localhost:44390/Exams/Student";

  constructor(private http: HttpClient) { }

  async getAllStudentExams(userId:string): Promise<any>  {
    return this.http.get(this.studentUrl+`?StudentId=${userId}`).toPromise<any>();
  }
}
