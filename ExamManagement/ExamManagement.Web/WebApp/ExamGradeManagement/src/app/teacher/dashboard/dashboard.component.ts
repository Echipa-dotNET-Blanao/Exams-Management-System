import { Component, OnInit } from '@angular/core';
import { TeacherService } from 'src/app/services/teacher.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  providers: [TeacherService]
})
export class DashboardComponent implements OnInit {
  constructor(private teacherService : TeacherService,private router: Router) { }

  ngOnInit() {
  }
  async logOut(){
    this.router.navigate(['/login']);
  }
  async showTeacherName(){
    
  }
}
