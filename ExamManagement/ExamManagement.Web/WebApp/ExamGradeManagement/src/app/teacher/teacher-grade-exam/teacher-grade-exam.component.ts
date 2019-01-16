import { Component, OnInit } from '@angular/core';
import { TeacherService } from '../../services/teacher.service';

@Component({
  selector: 'app-teacher-grade-exam',
  templateUrl: './teacher-grade-exam.component.html',
  styleUrls: ['./teacher-grade-exam.component.scss'],
  providers : [TeacherService]
})
export class TeacherGradeExamComponent implements OnInit {

  constructor(private tchServ: TeacherService) { }

  ngOnInit() {
    this.getExams(22);
  }

  async getExams(examId: number) {
    console.log("a intrat");
    const result = await this.tchServ.getExamStudents(examId);
    console.log(result);
    return result;
  }

}
