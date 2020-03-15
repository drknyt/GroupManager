import { Component } from '@angular/core';
import { ApiService } from './api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'GroupClient';
  users = [];

  constructor(private apiService: ApiService) {}

  getUsers() {
    this.apiService.getUsers().subscribe(
      res => {
        this.users = res;
        console.log(res);
      }
    )
  }

 }
