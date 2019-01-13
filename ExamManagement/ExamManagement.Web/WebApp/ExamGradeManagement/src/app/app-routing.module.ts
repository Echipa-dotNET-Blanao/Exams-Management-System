import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthComponent } from './login/auth/auth.component';
import { StudentDashboardComponent } from './student/student-dashboard/student-dashboard.component';
import { DashboardComponent } from './teacher/dashboard/dashboard.component';
import { TeacherGradeExamComponent } from './teacher/teacher-grade-exam/teacher-grade-exam.component';

const routes: Routes = [
  {
    path: 'login',
    component: AuthComponent
  },
  {
    path: 'student',
    component: StudentDashboardComponent
  },
  {
    path: 'teacher-dashboard',
    component: DashboardComponent
  },
  {
    path: 'teacher-grades',
    component: TeacherGradeExamComponent
  },
  {
    path: '**',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
