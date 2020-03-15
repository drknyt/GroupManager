import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from './user.interface';
import { UserService } from './user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  users: User[];
  originalUsers: User[];
  editRowId: number = 0;

  constructor(private router: Router, private userService: UserService) { }

  ngOnInit() {
    this.userService.getUsers()
      .subscribe(data => {
        this.users = data;
        this.originalUsers = JSON.parse(JSON.stringify(this.users));
      }, fail => {
        alert("Error Occured , for more details , please check the error log  ");
      });
  }

  deleteUser(user: User): void {
    if (this.editRowId > 0) {
      alert("Please save or discard your changes first before delete another record.");
    } else {

      if (confirm("Are you sure you want to delete this record ?")) {

        if (user.userId == 0) {
          let user: User = this.users.find(a => a.userId == 0);
          this.users = this.users.filter(obj => obj !== user);
        }
        else {
          this.userService.deleteUser(user.userId)
            .subscribe(result => {
              let userObj = this.users.find(u => u.userId == user.userId);
              let index = this.users.indexOf(userObj);
              this.users[index] = result;
              this.originalUsers = JSON.parse(JSON.stringify(this.users));
            }, fail => {
              alert("Error Occured , for more details , please check the error log  ");
            });
        }
      }
    }
  };

  edit(id: number) {
    if (this.editRowId > 0) {
      alert("Please save or discard your changes first before edit another record.");
    }
    else {
      this.editRowId = id;
    }
  }

  cancel() {
    this.users = JSON.parse(JSON.stringify(this.originalUsers));
    this.editRowId = 0;
  }

  save(user: User): void {
    if (user.userId > 0) {
      this.userService.updateUser(user).subscribe((result) => {

        let userObj = this.users.find(u => u.userId == user.userId);
        let index = this.users.indexOf(userObj);
        this.users[index] = result;
        this.originalUsers = JSON.parse(JSON.stringify(this.users));
        this.editRowId = 0;
      }, fail => {
        alert("Error Occured , for more details , please check the error log  ");
      })
    }
    else {
      this.userService.createUser(user).subscribe((result) => {
        let userObj = this.users.find(u => u.userId == user.userId);
        let index = this.users.indexOf(userObj);
        this.users[index] = result;
        this.originalUsers = JSON.parse(JSON.stringify(this.users));
        this.editRowId = 0;
      }, fail => {
        alert("Error Occured , for more details , please check the error log  ");
      });
    }
  };

  add() {

    if (this.editRowId > 0) {
      alert("Please save or discard your changes first before add a new record.");
    }
    else {
      let user: User = {
        userId: 0,
        userName: "",
        firstName: "",
        lastName: "",
        password: "",
        userGroups: [],
      };
      this.users.push(user);
    }
  };
}
