import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { TeacherGradeExamComponent } from './teacher-grade-exam/teacher-grade-exam.component';
import { DashboardComponent } from './dashboard/dashboard.component';


@NgModule({
  declarations: [TeacherGradeExamComponent, DashboardComponent],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
    TeacherGradeExamComponent,
    DashboardComponent
  ]
})
export class TeacherModule { }
