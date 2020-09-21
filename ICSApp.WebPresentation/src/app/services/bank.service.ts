import { ContaModel } from './../models/conta';
import { CorrentistaModel } from './../models/correntista';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { LoginModel } from '../models/login';
import { UsuarioModel } from '../models/usuario';

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
export class BankService {

  constructor(private http: HttpClient) {
  }

  Login(request: LoginModel) {
    return this.http.post<any>(API + 'Authentication/loginCompliance', request, httpOptions);
  }

  TerceiroPasso() {
    return this.http.get<any>(API + 'Authentication/TerceiroPasso');
  }

  Logout() {
    return this.http.post<any>(API + 'Authentication/logout', null, httpOptions);
  }

  criarCorrentista(request: CorrentistaModel) {
    return this.http.post<any>(API + 'commands/criarCorrentista', request, httpOptions);
  }

  criarUsuario(request: UsuarioModel) {
    return this.http.post<any>(API + 'commands/criarUsuario', request, httpOptions);
  }

  criarConta(request: ContaModel) {
    return this.http.post<any>(API + 'commands/criarConta', request, httpOptions);
  }

}
