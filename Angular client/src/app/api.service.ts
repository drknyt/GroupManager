import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  apiUrl = 'http://localhost:5000/api/users';
  token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE1ODQ4ODg4ODh9.1XDf_7FIwZqHetEs5nvX2ZkjdKSDtSjGYLOOOTfIpFU';

  constructor(private http: HttpClient) { }

  getUsers(): Observable<any> {
    var headers = { 'Authorization': 'Bearer ' + this.token }
    return this.http.get<any>(this.apiUrl, { headers });
  }
}
