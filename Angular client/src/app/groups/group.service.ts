import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Group } from "./group.interface";
import { Observable } from 'rxjs';

@Injectable()
export class GroupService {
  constructor(private http: HttpClient) { }
  baseUrl: string = 'http://localhost:55503/api/groups';

  getGroups() {
    return this.http.get<Group[]>(this.baseUrl, {
      headers: new HttpHeaders({
        "Authorization": "Bearer " + localStorage.getItem("jwt"),
        "Content-Type": "application/json"
      })});
  }

  getGroupById(id: number) {
    return this.http.get<Group>(this.baseUrl + '/' + id , {
      headers: new HttpHeaders({
        "Authorization": "Bearer " + localStorage.getItem("jwt"),
        "Content-Type": "application/json"
      })});
  }

  createGroup(group: Group): Observable<any> {
    return this.http.post(this.baseUrl, group, {
      headers: new HttpHeaders({
        "Authorization": "Bearer " + localStorage.getItem("jwt"),
        "Content-Type": "application/json"
      })});
  }

  updateGroup(group: Group): Observable<any> {
    return this.http.put(this.baseUrl + '/', group, {
      headers: new HttpHeaders({
        "Authorization": "Bearer " + localStorage.getItem("jwt"),
        "Content-Type": "application/json"
      })});
  }

  deleteGroup(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + '/' + id, {
      headers: new HttpHeaders({
        "Authorization": "Bearer " + localStorage.getItem("jwt"),
        "Content-Type": "application/json"
      })});
  }

  getuserGroups(): Observable<any> {
    let userId: string = localStorage.getItem("jwt_UserId");
    return this.http.get(this.baseUrl + '/userGroups/' + userId, {
      headers: new HttpHeaders({
        "Authorization": "Bearer " + localStorage.getItem("jwt"),
        "Content-Type": "application/json"
      })});
  }

/*
  addUserFavouriteMovies(groupId: number): Observable<any> {
    let userId: string = localStorage.getItem("jwt_UserId");
    return this.http.post(this.baseUrl + '/AddfavouriteMovies/' + userId, groupId, {
      headers: new HttpHeaders({
        "Authorization": "Bearer " + localStorage.getItem("jwt"),
        "Content-Type": "application/json"
      })});
  }

  deleteUserFavouriteMovies(movieId: number): Observable<any> {
    let userId: string = localStorage.getItem("jwt_UserId");
    return this.http.delete(this.baseUrl + '/DeletefavouriteMovies/' + userId + '/' + movieId, {
      headers: new HttpHeaders({
        "Authorization": "Bearer " + localStorage.getItem("jwt"),
        "Content-Type": "application/json"
      })});
  }*/
}
