import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { LoginModule } from './login/login.module';
import { StudentModule } from './student/student.module';
import { TeacherModule } from './teacher/teacher.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LoginModule,
    TeacherModule,
    StudentModule
  ],
  providers: [LoginModule,TeacherModule,StudentModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
