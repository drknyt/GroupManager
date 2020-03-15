import { Component } from '@angular/core';
import { JwtHelper } from 'angular2-jwt';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'my-app';
  userName = "";

  constructor(private jwtHelper: JwtHelper, private router: Router) {
  }

  isUserAuthenticated() {
    let token: string = localStorage.getItem("jwt");
    let fullName: string = localStorage.getItem("jwt_fullName");
    
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      this.userName = fullName;
      return true;
    }
    else {
      return false;
    }
  }

  logOut() {
    localStorage.removeItem("jwt");
    this.router.navigate(["/"]);
 }

}
