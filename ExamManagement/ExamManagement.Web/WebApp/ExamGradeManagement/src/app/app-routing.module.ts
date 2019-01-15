import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthComponent } from './login/auth/auth.component';
import { DashboardComponent } from './teacher/dashboard/dashboard.component';
import { TeacherGradeExamComponent } from './teacher/teacher-grade-exam/teacher-grade-exam.component';
import { IstoricExamenContentComponent } from './student/istoric-examen-content/istoric-examen-content.component'
import { HomeContentComponent } from './student/home-content/home-content.component';
import { ExamenContentComponent } from './student/examen-content/examen-content.component';
import { ContestatiiContentComponent } from './student/contestatii-content/contestatii-content.component';


const routes: Routes = [
  {
    path: 'login',
    component: AuthComponent
  },
  {
    path: 'student-dashboard',
    component: HomeContentComponent
  },
  {
    path: 'student-dashboard/examene',
    component: ExamenContentComponent
  },
  {
    path: 'student-dashboard/istoric-examene',
    component: IstoricExamenContentComponent
  },
  {
    path: 'student-dashboard/contestatii',
    component: ContestatiiContentComponent
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
