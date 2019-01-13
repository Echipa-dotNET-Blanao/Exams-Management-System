import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeacherGradeExamComponent } from './teacher-grade-exam/teacher-grade-exam.component';

@NgModule({
  declarations: [TeacherGradeExamComponent],
  imports: [
    CommonModule
  ],
  exports: [
    TeacherGradeExamComponent
  ]
})
export class TeacherModule { }
