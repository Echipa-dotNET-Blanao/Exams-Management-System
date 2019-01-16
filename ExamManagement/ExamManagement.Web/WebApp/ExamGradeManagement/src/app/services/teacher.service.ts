import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {

  examUrl: string = 'https://localhost:44390/Grades/All';
  teacherUrl = 'https://localhost:44390/Teachers';

  constructor (private http: HttpClient) {}

  async getExamStudents(examId: number): Promise<any> {
    return this.http.get(this.examUrl + `?examId=${examId}`).toPromise<any>();
  }

  async getTeacherInfo(teacherId: number):Promise<any> {
    return this.http.get(this.teacherUrl + `?teacherId=${teacherId}`).toPromise<any>();
  }

  async getTeacherName(teacherId:number):Promise<any>{
    return this.http.get(this.teacherUrl + `?TeacherId=${teacherId}`).toPromise<any>();
  }
}
