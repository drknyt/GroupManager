import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { GroupService } from '../group.service';
import { Group } from '../group.interface';

@Component({
  selector: 'app-groups-form',
  templateUrl: './groups-form.component.html',
  styleUrls: ['./groups-form.component.css']
})
export class GroupsFormComponent implements OnInit {
  model: Group = {
    groupId: 0,
    groupName: '',
    groupAdmin : 0
  };
  currentFormId: string;

  constructor(private router: Router, private groupService: GroupService, private activatedRoute: ActivatedRoute) {

  }

  ngOnInit() {
    this.loadItem();
  }

  loadItem() {
    this.currentFormId = this.activatedRoute.snapshot.params['id'];
    if (this.currentFormId.length > 0) {
      let id = parseInt(this.currentFormId);
      if (id > 0) {
        this.groupService.getGroupById(id).subscribe(data => {
          this.model = data;
        }, fail => {
          alert("Error Occured , for more details , please check the error log  ");
        });
      }
      else {
        this.model = {
          groupId: 0,
          groupName: "",
          groupAdmin : 0
        };
      }
    }
  }

  onSubmit() {
    if (this.model.groupId > 0) {
      this.groupService.updateGroup(this.model).subscribe(result => {
        this.router.navigate(["groups"]);
      }, error => {
        alert("Error updating the group");
      });
    }
    else {
      this.groupService.createGroup(this.model).subscribe(result => {
        this.router.navigate(["groups"]);
      }, error => {
        alert("Error adding the group");
      });
    }
  }
}