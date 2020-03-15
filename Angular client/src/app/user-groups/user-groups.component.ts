import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Group } from '../groups/group.interface';
import { GroupService } from '../groups/group.service';

@Component({
  selector: 'app-user-group',
  templateUrl: './user-groups.component.html',
  styleUrls: ['./user-groups.component.css']
})
export class UserGroupComponent implements OnInit {

  groups: Group[];
  allgroups: Group[];
  selectedValue: number;

  constructor(private router: Router, private groupService: GroupService) { }

  ngOnInit() {
    this.loadGroups();
    this.loadAllGroups();
  }

  loadGroups() {
    this.groupService.getuserGroups()
      .subscribe(data => {
        this.groups = data;
      }, fail => {
        alert("Error Occured , for more details , please check the error log  ");
      });
  }

  loadAllGroups() {
    this.groupService.getGroups()
      .subscribe(data => {
        this.allgroups = data;
        this.selectedValue = this.allgroups[0].groupId;
      }, fail => {
        alert("Error Occured , for more details , please check the error log  ");
      });
  }
/*
  add() {
    this.groupService.add(this.selectedValue).subscribe(success => {
      this.loadMovies();
    }, fail => {
      alert("Can't add this movie due to dublication");
    });
  }

  delete(movie : Movie) {
    this.movieService.deleteUserFavouriteMovies(movie.movieId).subscribe(success => {
      this.loadMovies();
    }, fail => {
      alert("Can't delete this movie due to dublication");
    });
  }*/
}
