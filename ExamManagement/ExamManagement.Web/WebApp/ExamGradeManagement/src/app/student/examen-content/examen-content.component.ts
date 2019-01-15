import { Component, OnInit,Input } from '@angular/core';
import { StudentService } from 'src/app/services/student.service';
import { Exam } from '../../shared/models/exam';

@Component({
  selector: 'app-examen-content',
  templateUrl: './examen-content.component.html',
  styleUrls: ['./examen-content.component.scss'],
  providers : [StudentService]
})
export class ExamenContentComponent implements OnInit {

  exams:Exam[];
  @Input()
  studentId:string;

  constructor(private studServ:StudentService) { }

  ngOnInit() {
    this.getAllExamsForStudent('JCPD2JFUEOJF2KFJ9');
  }

  async getAllExamsForStudent(userId:string) {

    var result = await this.studServ.getAllStudentExams(userId);
    this.exams=result;
    console.log(this.exams);
    console.log(this.studentId);
  }

}
