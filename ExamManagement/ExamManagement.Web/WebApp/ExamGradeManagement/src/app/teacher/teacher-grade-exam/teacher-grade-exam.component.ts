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
    console.log(result);
  }

  sendGrade(newGrade: number, gradeId: number) {
    if (newGrade <= 10 || newGrade >= 1) {
      console.log(newGrade, gradeId);
      this.tchServ.updateGrade(gradeId, newGrade);

    }
  }

  async getTeacherName(teacherId: number) {
    const result = await this.tchServ.getTeacherInfo(teacherId);
    this.teacherName = result['fullName'];
  }

}
