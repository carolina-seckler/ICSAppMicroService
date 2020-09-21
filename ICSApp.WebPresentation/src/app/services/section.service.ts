import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';

const API = environment.activityApiEndpoint;

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
export class SectionService {

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<any>(API + 'Section');
  }

  getById(request: number){
    return this.http.get<any>(API + 'Section/' + request);
  }
}
