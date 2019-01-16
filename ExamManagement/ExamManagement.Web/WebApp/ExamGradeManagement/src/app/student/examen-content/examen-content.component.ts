import { Component, OnInit,Input } from '@angular/core';
import { StudentService } from 'src/app/services/student.service';
import { Exam } from '../../shared/models/exam';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-examen-content',
  templateUrl: './examen-content.component.html',
  styleUrls: ['./examen-content.component.scss'],
  providers : [StudentService]
})
export class ExamenContentComponent implements OnInit {

  exams:Exam[];
  username:string;
  
  constructor(private studServ:StudentService, private cookieService:CookieService) { }

  ngOnInit() {
    this.username = this.cookieService.get('Username');
    this.getAllExamsForStudent(this.username);
  }



  async getAllExamsForStudent(userId:string) {
    var result = await this.studServ.getAllStudentExams(userId);
    this.exams=result;
  }

}
