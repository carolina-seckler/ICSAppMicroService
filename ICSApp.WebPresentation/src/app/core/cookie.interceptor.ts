import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, throwError, BehaviorSubject } from 'rxjs';
import { catchError, map, switchMap, finalize, filter, take } from 'rxjs/operators';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';


@Injectable()
export class CookieInterceptor implements HttpInterceptor {

  constructor(private router: Router) { }

  tokenSubject: BehaviorSubject<string> = new BehaviorSubject<string>(null);
  isRefreshingToken: Boolean;

  intercept(req: HttpRequest<any>, next: HttpHandler) {

    if (environment.type == 'local') {

      return next.handle(this.addToken(req, localStorage.getItem('access_token')))
      .pipe(catchError(err => {
        if (!req.params.has('loginpage')) {
          if (err instanceof HttpErrorResponse) {
            if (err.status === 401) {
              // this.extMethods.showNotification("Sessão Expirada.", "danger");
              this.router.navigate(['./login']);
              return throwError(err);

            } else if (err.status === 403) {

              if (err.error != null) {
                if (err.error.Message == "Não foi possivel identificar o usuário") {
                  // return this.handleUnauthorized(req, next);
                } else {
                  // this.extMethods.showNotification(err.error.Message, "danger");
                  return throwError(err);
                }
              } else {
                // this.extMethods.showNotification("Usuário não autorizado.", "danger");
                return throwError(err);
              }

            } else if (err.status === 400) {
              if (err.error.Type === 'Warning') {
                // this.extMethods.showNotification(err.error.Message, "warning");
              } else {
                // this.extMethods.showNotification(err.error.Message, "danger");
              }
              return throwError(err);
            } else if (err.status === 500) {
              // this.extMethods.showNotification(err.error.Message, "danger");
              return throwError(err);
            } else {
              return throwError(err);
            }
          } else {
            // this.extMethods.showNotification("Ocorreu um erro não esperado na aplicação.", "danger");
            return throwError(err);
          }
        } else {
          return throwError(err);
        }
      }));

    }
  }

  // handleUnauthorized(req: HttpRequest<any>, next: HttpHandler): Observable<any> {
  //   if (!this.isRefreshingToken) {
  //     this.isRefreshingToken = true;

  //     this.tokenSubject.next(null);
  //     req.params.has('loginpage');
  //     return this.authService.refreshToken()
  //     .pipe(switchMap((newToken: any) => {

  //       if (localStorage.getItem('access_token')) {
  //         this.tokenSubject.next(localStorage.getItem('access_token'));
  //         return next.handle(this.addToken(req, localStorage.getItem('access_token')));
  //       }
  //       return throwError('error');
  //     })
  //     , catchError(error => {
  //       this.router.navigate(['./login']);
  //       return throwError(error);
  //     })
  //     , finalize(() => {
  //       this.isRefreshingToken = false;
  //     })
  //     );
  //   } else {
  //     return this.tokenSubject
  //     .pipe(
  //       filter(token => token != null)
  //       , take(1)
  //       , switchMap(token => {
  //         return next.handle(this.addToken(req, token));
  //       })
  //       );
  //     }
  //   }

    private addToken(request: HttpRequest<any>, token: string) {
      return request.clone({
        setHeaders: {
          'Authorization': `Bearer ${token}`
        }
      });
    }
}
