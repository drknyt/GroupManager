import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  apiUrl = 'http://localhost:55503/api/users';
  token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE1ODQyODUxNTV9.CitT1zY8KT67EMXY27FgeOtPFa0VxvXnTQ4HilqcI-E';

  constructor(private http: HttpClient) { }

  getUsers(): Observable<any> {
    var headers = { 'Authorization': 'Bearer ' + this.token }
    return this.http.get<any>(this.apiUrl, { headers });
  }
}
