import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './_components/nav-menu/nav-menu.component';
import { HomeComponent } from './_components/home/home.component';
import { CounterComponent } from './_components/counter/counter.component';
import { FetchDataComponent } from './_components/fetch-data/fetch-data.component';
import { LoginComponent } from './_components/login';
import { RegisterComponent } from './_components/register';
import { AuthGuard } from './_guards';
import { AlertComponent } from './_directives';
import { AlertService, AuthenticationService, UserService, SeasonService } from './_services';
import { JwtInterceptor, ErrorInterceptor } from './_helpers';
import { ApplyComponent } from './_components/apply/apply.component';
import { CoursesComponent } from './_components/courses/courses.component';
import { SemesterService } from './_services/semester.service';
import { ApplicationService } from './_services/application.service';
import { AppliedComponent } from './_components/applied/applied.component';
import { CourseComponent } from './_components/course/course.component';
import { CourseService } from './_services/course.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent,
    RegisterComponent,
    AlertComponent,
    ApplyComponent,
    CoursesComponent,
    CourseComponent,
    AppliedComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuard] },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'apply/:id', component: ApplyComponent },
      { path: 'applied', component: AppliedComponent },
      { path: 'courses', component: CoursesComponent },
      { path: 'course/:id', component: CourseComponent },
      { path: '**', redirectTo: '' }
    ])
  ],
  providers: [
    AuthGuard,
    AlertService,
    AuthenticationService,
    UserService,
    SeasonService,
    SemesterService,
    ApplicationService,
    CourseService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
],
  bootstrap: [AppComponent]
})
export class AppModule {}
