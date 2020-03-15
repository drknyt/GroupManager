import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GroupService } from './group.service';
import { Group } from './group.interface';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.css']
})
export class GroupsComponent implements OnInit {
  groups: Group[];

  constructor(private router: Router, private groupService: GroupService) { }

  ngOnInit() {
    this.loadGroups();
  }

  loadGroups() {
    this.groupService.getGroups()
      .subscribe(data => {
        this.groups = data;
      }, fail => {
        alert("Error Occured , for more details , please check the error log  ");
      });
  }

  add() {
    this.router.navigate(["groups-form/0"]);
  }

  edit(group: Group) {
    this.router.navigate(["groups-form", group.groupId]);
  }

  delete(group: Group) {
    if (confirm("Are you sure you want to delete this group?")) {
      this.groupService.deleteGroup(group.groupId).subscribe(success => {
        this.loadGroups();
      }, fail => {
        alert("Error Deleting the group");
      })
    }
  }
}
