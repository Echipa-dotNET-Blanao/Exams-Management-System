import { Component, OnInit } from '@angular/core';
import { TeacherService } from 'src/app/services/teacher.service';
import { Router } from '@angular/router';
import { JSONP_ERR_WRONG_METHOD } from '@angular/common/http/src/jsonp';
import { HttpClientJsonpModule } from '@angular/common/http';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  providers: [TeacherService]
})
export class DashboardComponent implements OnInit {
  teacherName:string;
  constructor(private teacherService : TeacherService,private router: Router) { }

  ngOnInit() {
  }
  async logOut(){
    this.router.navigate(['/login']);
  }
  async showTeacherName(){
    console.log("I'm in");
    const result = await this.teacherService.getTeacherInfo(1);
    const resp = JSON.parse(JSON.stringify(result));
    console.log(resp);
    console.log(result);
    this.teacherName = resp["fullName"];
    return result;
    
  }
}
