import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsersComponent } from './users/users.component';
import { ContactUsComponent } from './contact-us/contact-us.component'
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './guards/auth-guard.service';
import { GroupsComponent } from './groups/groups.component';
import { UserGroupComponent } from './user-groups/user-groups.component';
import { GroupsFormComponent } from './groups/groups-form/groups-form.component';
import { UsersFormComponent } from './users/users-form/users-form.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'users', component: UsersComponent },
  { path: 'contact', component: ContactUsComponent , canActivate : [AuthGuard] },
  { path: 'groups', component: GroupsComponent , canActivate : [AuthGuard] },
  { path: 'user-group', component: UserGroupComponent , canActivate : [AuthGuard] },
  { path: 'groups-form/:id', component: GroupsFormComponent , canActivate : [AuthGuard] },
  { path: 'users-form/:id', component: UsersFormComponent },
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
