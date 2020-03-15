import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {UserService} from '../users/user.service';
import { NgForm } from '@angular/forms';
import { JwtHelper } from 'angular2-jwt';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  invalidLogin: boolean;
  constructor(private router: Router, private userService: UserService ,
    private jwtHelper: JwtHelper ) { }
  ngOnInit() {
  }

  login(form: NgForm) { 
    this.userService.login(form.value).subscribe(response => {
      let token = (<any>response).token;
      let fullName = (<any>response).firstName+' '+(<any>response).lastName;
      let userId = (<any>response).userId;

      localStorage.setItem("jwt", token);
      localStorage.setItem("jwt_fullName", fullName);
      localStorage.setItem("jwt_UserId",userId);
      
      this.invalidLogin = false;
      this.router.navigate(["/"]);
    }, err => {
      this.invalidLogin = true;
    });
  }
}
