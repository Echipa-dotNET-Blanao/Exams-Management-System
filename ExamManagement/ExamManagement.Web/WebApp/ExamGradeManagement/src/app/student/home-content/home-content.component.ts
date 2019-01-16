import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-home-content',
  templateUrl: './home-content.component.html',
  styleUrls: ['./home-content.component.scss']
})

export class HomeContentComponent implements OnInit {

  username:string;

  constructor(private cookieService:CookieService) { }

  ngOnInit() {
    this.username = this.cookieService.get('Username');
  }

}
