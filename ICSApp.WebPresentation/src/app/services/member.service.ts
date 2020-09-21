import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { MemberModel } from '../models/member';

const API = environment.incidentApiEndpoint;

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json;charset=utf-8',
  })
};

const httpOptionsAuth = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json;charset=utf-8',
  }),
  withCredentials: true
};

@Injectable({
  providedIn: 'root'
})
export class MemberService {

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<any>(API + 'Member');
  }

  insert(request: MemberModel) {
    return this.http.post<any>(API + 'Member', request, httpOptions);
  }

  update(request: MemberModel) {
    return this.http.put<any>(API + 'Member', request, httpOptions);
  }

  delete(request: number){
    return this.http.delete<any>(API + 'Member/' + request);
  }
}
