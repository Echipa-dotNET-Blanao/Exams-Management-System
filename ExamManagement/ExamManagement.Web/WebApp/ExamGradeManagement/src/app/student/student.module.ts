import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentDashboardComponent } from './student-dashboard/student-dashboard.component';

@NgModule({
  declarations: [StudentDashboardComponent],
  imports: [
    CommonModule
  ],
  exports: [
    StudentDashboardComponent,
  ]
})
export class StudentModule { }
