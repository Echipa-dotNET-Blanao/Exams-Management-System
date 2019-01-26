import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {

  examUrl: string = 'https://localhost:44390/Grades/All';
  teacherUrl: string = 'https://localhost:44390/api/Teachers';
  updateGradeUrl: string = 'https://localhost:44390/Grades';

  constructor (private http: HttpClient) {}

  async getExamStudents(examId: number): Promise<any> {
    return this.http.get(this.examUrl + `?examId=${examId}`).toPromise<any>();
  }

  async getTeacherInfo(TeacherID: number): Promise<any>{
    return this.http.get(this.teacherUrl + `?TeacherID=${TeacherID}`).toPromise<any>();
  }

  async updateGrade(gradeId: number, grade: number): Promise<any> {
    const body = {gradeId: gradeId, grade: grade};
    return this.http.put(this.updateGradeUrl, body).toPromise<any>();
  }
}
