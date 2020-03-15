import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService} from '../user.service';
import { User } from '../user.interface';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-users-form',
  templateUrl: './users-form.component.html',
  styleUrls: ['./users-form.component.css']
})
export class UsersFormComponent implements OnInit {
  model: User = {
    userId:0,
    userName :'',
    password : '',
    firstName : '',
    lastName :''
  };
  currentFormId: string;

  constructor(private router: Router, private userService: UserService, private activatedRoute: ActivatedRoute) {

  }

  ngOnInit() {
    this.loadItem();
  }

  loadItem() {
    this.currentFormId = this.activatedRoute.snapshot.params['id'];
    if (this.currentFormId.length > 0) {
      let id = parseInt(this.currentFormId);
      if (id > 0) {
        this.userService.getUserById(id).subscribe(data => {
          this.model = data;
        }, fail => {
          alert("Error Occured , for more details , please check the error log  ");
        });
      }
      else {
        this.model = {
         userId : 0,
         firstName : '',
         lastName :'',
         userName : '',
         password : ''
        };
      }
    }
  }

  onSubmit() {
    if (this.model.userId > 0) {
      this.userService.updateUser(this.model).subscribe(result => {
        this.router.navigate(["groups"]);
      }, error => {
        alert("Error updating the user");
      });
    }
    else {
      this.userService.createUser(this.model).subscribe(result => {
        this.router.navigate(["groups"]);
      }, error => {
        alert("Error adding the user");
      });
    }
  }
}