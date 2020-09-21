import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { LoginModule } from './pages/login/login.module';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { NavComponent } from './components/nav/nav.component';
import { FooterComponent } from './components/footer/footer.component';
import { HomeModule } from './pages/home/home.module';
import { PathLocationStrategy, LocationStrategy, HashLocationStrategy } from '@angular/common';
import { CookieInterceptor } from './core/cookie.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    NotFoundComponent,
    NavComponent,
    FooterComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    LoginModule,
    HomeModule,
    HttpClientModule,
    ServiceWorkerModule.register('ngsw-worker.js',
      {
        enabled: environment.production
      }),
  ],
  providers: [
    PathLocationStrategy,
    { provide: LocationStrategy, useClass: HashLocationStrategy },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: CookieInterceptor,
      multi: true
    }
  ],
  bootstrap: [
    AppComponent
  ],
  exports: [
    NotFoundComponent,
    NavComponent,
    FooterComponent
  ]
})
export class AppModule { }
