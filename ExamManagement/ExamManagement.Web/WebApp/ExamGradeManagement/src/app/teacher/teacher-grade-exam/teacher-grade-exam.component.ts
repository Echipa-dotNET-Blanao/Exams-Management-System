import { Component, OnInit } from '@angular/core';
import { TeacherService } from '../../services/teacher.service';
import { Grade } from '../../shared/models/grade';
import { Teacher } from '../../shared/models/teacher';

@Component({
  selector: 'app-teacher-grade-exam',
  templateUrl: './teacher-grade-exam.component.html',
  styleUrls: ['./teacher-grade-exam.component.scss'],
  providers : [TeacherService]
})
export class TeacherGradeExamComponent implements OnInit {

  grade: Grade[];
  teacherName: Teacher[];

  constructor(private tchServ: TeacherService) { }

  ngOnInit() {
    this.getExams(22);
    this.getTeacherName(2);
  }

  async getExams(examId: number) {

    const result = await this.tchServ.getExamStudents(examId);
    this.grade = result;
  }

  sendGrade(newGrade: number) {
    if (newGrade) {
      console.log(newGrade);
    }
  }

  async getTeacherName(teacherId: number) {
    const result = await this.tchServ.getTeacherName(teacherId);
    this.teacherName = result;
  }

}
