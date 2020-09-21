import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { UserModel } from '../models/user';
import { tap } from 'rxjs/operators';

const INCIDENT_API = environment.incidentApiEndpoint;
const ACTIVITY_API = environment.activityApiEndpoint;

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
export class UserService {

  constructor(private http: HttpClient) { }

  getIncidentUser() {
    return this.http.get<any>(INCIDENT_API + 'User');
  }

  getActivityUser() {
    return this.http.get<any>(ACTIVITY_API + 'User');
  }

  signIn(request: UserModel) {
    return this.http.post<any>(INCIDENT_API + 'User', request, httpOptionsAuth)
      .pipe(tap(res => {
        //Dev
        if (environment.type === 'local') {
          localStorage.setItem('access_token', res.access_Token);
          localStorage.setItem('expires_In', res.expires_In);
          localStorage.setItem('created', res.created);
        }
      }))
  }
}
