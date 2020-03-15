import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from "./user.interface";
import { Observable } from 'rxjs';

@Injectable()
export class UserService {
  constructor(private http: HttpClient) { }
  baseUrl: string = 'http://localhost:55503/api/users';
  
  getUsers() {
    return this.http.get<User[]>(this.baseUrl, {
      headers: new HttpHeaders({
        "Authorization": "Bearer " + localStorage.getItem("jwt"),
        "Content-Type": "application/json"
      })});
  }

  getUserById(id: number) {
    return this.http.get<User>(this.baseUrl + '/' + id,{
      headers: new HttpHeaders({
        "Authorization": "Bearer " + localStorage.getItem("jwt"),
        "Content-Type": "application/json"
      })});
  }

  createUser(user: User): Observable<any> {
    return this.http.post(this.baseUrl, user,{
      headers: new HttpHeaders({
        "Authorization": "Bearer " + localStorage.getItem("jwt"),
        "Content-Type": "application/json"
      })});
  }

  updateUser(user: User): Observable<any> {
    return this.http.put(this.baseUrl + '/', user,{
      headers: new HttpHeaders({
        "Authorization": "Bearer " + localStorage.getItem("jwt"),
        "Content-Type": "application/json"
      })});
  }

  deleteUser(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + '/' + id,{
      headers: new HttpHeaders({
        "Authorization": "Bearer " + localStorage.getItem("jwt"),
        "Content-Type": "application/json"
      })});
  }

  login(credentials: string): Observable<any> {
    let credentialsJson = JSON.stringify(credentials);
    return this.http.post(this.baseUrl + '/authenticate', credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }
}
