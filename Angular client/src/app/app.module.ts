import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UsersComponent } from './users/users.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { UserService } from './users/user.service';
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from '@angular/forms';
import { JwtHelper } from 'angular2-jwt'
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './guards/auth-guard.service';
import { GroupsComponent } from './groups/groups.component';
import { UserGroupComponent } from './user-groups/user-groups.component';
import { GroupService } from './groups/group.service';
import { GroupsFormComponent } from './groups/groups-form/groups-form.component';
import { UsersFormComponent } from './users/users-form/users-form.component';


@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    ContactUsComponent,
    LoginComponent,
    HomeComponent,
    GroupsComponent,
    UserGroupComponent,
    GroupsFormComponent , 
    UsersFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [UserService, JwtHelper,AuthGuard,GroupService],
  bootstrap: [AppComponent]
})
export class AppModule { }
