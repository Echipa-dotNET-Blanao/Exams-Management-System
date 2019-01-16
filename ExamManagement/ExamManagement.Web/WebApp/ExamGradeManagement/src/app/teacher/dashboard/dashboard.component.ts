import { Component, OnInit } from '@angular/core';
import { TeacherService } from 'src/app/services/teacher.service';
import { Router } from '@angular/router';
import { JSONP_ERR_WRONG_METHOD } from '@angular/common/http/src/jsonp';
import { HttpClientJsonpModule } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  providers: [TeacherService]
})
export class DashboardComponent implements OnInit {

  
  username:string;
  teacherName:string;
  constructor(private teacherService : TeacherService,private router: Router, private cookieService: CookieService) { }

  ngOnInit() {
    this.username = this.cookieService.get('Username');
  }
  async logOut(){
    this.router.navigate(['/login']);
  }
  async showTeacherName(){
    console.log("I'm in");
    const result = await this.teacherService.getTeacherInfo(parseInt(this.username));
    const resp = JSON.parse(JSON.stringify(result));
    console.log(resp);
    console.log(result);
    this.teacherName = resp["fullName"];
    return result;
    
  }
}
