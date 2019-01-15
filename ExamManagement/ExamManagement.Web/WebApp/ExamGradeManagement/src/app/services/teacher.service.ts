import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {

  teacherUrl : string = 'https://localhost:44390/Exams/Teachers';

  constructor(private http: HttpClient) { }

  async getTeacherInformation(userId:string): Promise<any>  {
    return this.http.get(this.teacherUrl+`?TeacherId=${userId}`).toPromise<any>();
  }
}
