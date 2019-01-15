import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {

  examUrl : string = 'https://localhost:44390/Grades/All';

  constructor (private http: HttpClient) {}

  async getExamStudents(examId: number): Promise<any> {
    return this.http.get(this.examUrl + `?examId=${examId}`).toPromise<any>();
  }
}
