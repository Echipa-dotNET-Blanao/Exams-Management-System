import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-contestatii-content',
  templateUrl: './contestatii-content.component.html',
  styleUrls: ['./contestatii-content.component.scss']
})
export class ContestatiiContentComponent implements OnInit {
  
  username:string;

  constructor(private cookieService:CookieService) { }

  ngOnInit() {
    this.username = this.cookieService.get('Username');
  }

}
