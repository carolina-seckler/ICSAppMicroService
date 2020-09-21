import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';

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
export class FunctionService {

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<any>(API + 'Function');
  }

  getById(request: number){
    return this.http.get<any>(API + 'Function/' + request);
  }
}
