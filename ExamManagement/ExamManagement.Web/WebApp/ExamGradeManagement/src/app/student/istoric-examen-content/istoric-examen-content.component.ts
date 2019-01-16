import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-istoric-examen-content',
  templateUrl: './istoric-examen-content.component.html',
  styleUrls: ['./istoric-examen-content.component.scss']
})
export class IstoricExamenContentComponent implements OnInit {

  username:string;

  constructor(private cookieService:CookieService) { }

  ngOnInit() {
    this.username = this.cookieService.get('Username');
  }

}
