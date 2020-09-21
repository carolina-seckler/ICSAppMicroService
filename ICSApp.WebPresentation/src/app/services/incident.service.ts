import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { IncidentModel } from '../models/incident';

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
export class IncidentService {

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<any>(API + 'Incident');
  }

  insert(request: IncidentModel) {
    return this.http.post<any>(API + 'Incident', request, httpOptions);
  }

  update(request: IncidentModel) {
    return this.http.put<any>(API + 'Incident', request, httpOptions);
  }

  delete(request: number){
    return this.http.delete<any>(API + 'Incident/' + request);
  }
}
