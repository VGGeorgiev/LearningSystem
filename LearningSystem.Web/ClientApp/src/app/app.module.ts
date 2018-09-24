import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AlertsModule } from 'angular-alert-module';

import { AuthGuard, StudentAuthGuard } from './_guards';
import { TrainerAuthGuard } from './_guards/trainer.auth.guard';

import { AlertService, AuthenticationService, UserService, SeasonService, HomeworkService, LectureService, StudentsInCourseService } from './_services';
import { JwtInterceptor, ErrorInterceptor } from './_helpers';

import { SemesterService } from './_services/semester.service';
import { ApplicationService } from './_services/application.service';
import { CourseService } from './_services/course.service';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './_components/nav-menu/nav-menu.component';
import { HomeComponent } from './_components/home/home.component';
import { CounterComponent } from './_components/counter/counter.component';
import { FetchDataComponent } from './_components/fetch-data/fetch-data.component';
import { LoginComponent } from './_components/login';
import { RegisterComponent } from './_components/register';
import { AlertComponent } from './_directives';
import { ApplyComponent } from './_components/apply/apply.component';
import { CoursesComponent } from './_components/courses/courses.component';
import { AppliedComponent } from './_components/applied/applied.component';
import { CourseComponent } from './_components/course/course.component';
import { EvaluateComponent } from './_components/evaluate/evaluate.component';
import { ProfileComponent } from './_components/profile/profile.component';

import { TrainerPortalComponent } from './_components/trainer-portal/trainer.portal.component';
import { SeasonsCreateTrainerPortalComponent } from './_components/trainer-portal/seasons/seasons-create.trainer-portal.component';
import { SeasonsTrainerPortalComponent } from './_components/trainer-portal/seasons/seasons.trainer-portal.component';
import { SeasonsEditTrainerPortalComponent } from './_components/trainer-portal/seasons/seasons-edit.trainer-portal.component';
import { SemestersTrainerPortalComponent } from './_components/trainer-portal/semesters/semesters.trainer-portal.component';
import { SemestersCreateTrainerPortalComponent } from './_components/trainer-portal/semesters/semesters-create.trainer-portal.component';
import { SemestersEditTrainerPortalComponent } from './_components/trainer-portal/semesters/semesters-edit.trainer-portal.component';
import { CoursesTrainerPortalComponent } from './_components/trainer-portal/courses/courses.trainer-portal.component';
import { CoursesCreateTrainerPortalComponent } from './_components/trainer-portal/courses/courses-create.trainer-portal.component';
import { CoursesEditTrainerPortalComponent } from './_components/trainer-portal/courses/courses-edit.trainer-portal.component';
import { LecturesTrainerPortalComponent } from './_components/trainer-portal/lectures/lectures.trainer-portal.component';
import { LecturesCreateTrainerPortalComponent } from './_components/trainer-portal/lectures/lectures-create.trainer-portal.component';
import { LecturesEditTrainerPortalComponent } from './_components/trainer-portal/lectures/lectures-edit.trainer-portal.component';
import { HomeworkAssignmentsTrainerPortalComponent } from './_components/trainer-portal/homeworkAssignments/homeworkAssignments.trainer-portal.component';
import { HomeworkAssignmentsCreateTrainerPortalComponent } from './_components/trainer-portal/homeworkAssignments/homeworkAssignments-create.trainer-portal.component';
import { HomeworkAssignmentsEditTrainerPortalComponent } from './_components/trainer-portal/homeworkAssignments/homeworkAssignments-edit.trainer-portal.component';
import { UsersTrainerPortalComponent } from './_components/trainer-portal/users/users.trainer-portal.component';
import { UsersEditTrainerPortalComponent } from './_components/trainer-portal/users/users-edit.trainer-portal.component';
import { ApplicationsTrainerPortalComponent } from './_components/trainer-portal/applications/applications.trainer-portal.component';
import { StudentsInCourseTrainerPortalComponent } from './_components/trainer-portal/studentsInCourse/studentsInCourse.trainer-portal.component';

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
    AppliedComponent,
    EvaluateComponent,
    ProfileComponent,

    TrainerPortalComponent,
    SeasonsCreateTrainerPortalComponent,
    SeasonsTrainerPortalComponent,
    SeasonsEditTrainerPortalComponent,
    SemestersTrainerPortalComponent,
    SemestersCreateTrainerPortalComponent,
    SemestersEditTrainerPortalComponent,
    CoursesTrainerPortalComponent,
    CoursesCreateTrainerPortalComponent,
    CoursesEditTrainerPortalComponent,
    LecturesTrainerPortalComponent,
    LecturesCreateTrainerPortalComponent,
    LecturesEditTrainerPortalComponent,
    HomeworkAssignmentsTrainerPortalComponent,
    HomeworkAssignmentsCreateTrainerPortalComponent,
    HomeworkAssignmentsEditTrainerPortalComponent,
    UsersTrainerPortalComponent,
    UsersEditTrainerPortalComponent,
    ApplicationsTrainerPortalComponent,
    StudentsInCourseTrainerPortalComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    AlertsModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuard] },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'apply/:id', component: ApplyComponent, canActivate: [AuthGuard] },
      { path: 'applied', component: AppliedComponent, canActivate: [AuthGuard] },
      { path: 'courses', component: CoursesComponent, canActivate: [StudentAuthGuard] },
      { path: 'course/:id', component: CourseComponent, canActivate: [StudentAuthGuard] },
      { path: 'evaluate/:id', component: EvaluateComponent, canActivate: [StudentAuthGuard] },
      { path: 'profile/:username', component: ProfileComponent, canActivate: [StudentAuthGuard] },
      { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },

      { path: 'trainer-portal', component: TrainerPortalComponent, canActivate: [TrainerAuthGuard] },
      { path: 'trainer-portal/seasons', component: SeasonsTrainerPortalComponent, canActivate: [TrainerAuthGuard] },
      { path: 'trainer-portal/seasons-create', component: SeasonsCreateTrainerPortalComponent, canActivate: [TrainerAuthGuard] },
      { path: 'trainer-portal/seasons-edit/:id', component: SeasonsEditTrainerPortalComponent, canActivate: [TrainerAuthGuard] },
      { path: 'trainer-portal/semesters', component: SemestersTrainerPortalComponent, canActivate: [TrainerAuthGuard] },
      { path: 'trainer-portal/semesters-create', component: SemestersCreateTrainerPortalComponent, canActivate: [TrainerAuthGuard] },
      { path: 'trainer-portal/semesters-edit/:id', component: SemestersEditTrainerPortalComponent, canActivate: [TrainerAuthGuard] },
      { path: 'trainer-portal/courses', component: CoursesTrainerPortalComponent, canActivate: [TrainerAuthGuard] },
      { path: 'trainer-portal/courses-create', component: CoursesCreateTrainerPortalComponent, canActivate: [TrainerAuthGuard] },
      { path: 'trainer-portal/courses-edit/:id', component: CoursesEditTrainerPortalComponent, canActivate: [TrainerAuthGuard] },
      { path: 'trainer-portal/lectures', component: LecturesTrainerPortalComponent, canActivate: [TrainerAuthGuard] },
      { path: 'trainer-portal/lectures-create', component: LecturesCreateTrainerPortalComponent, canActivate: [TrainerAuthGuard] },
      { path: 'trainer-portal/lectures-edit/:id', component: LecturesEditTrainerPortalComponent, canActivate: [TrainerAuthGuard] },
      { path: 'trainer-portal/homework-assignments', component: HomeworkAssignmentsTrainerPortalComponent, canActivate: [TrainerAuthGuard] },
      { path: 'trainer-portal/homework-assignments-create', component: HomeworkAssignmentsCreateTrainerPortalComponent, canActivate: [TrainerAuthGuard] },
      { path: 'trainer-portal/homework-assignments-edit/:id', component: HomeworkAssignmentsEditTrainerPortalComponent, canActivate: [TrainerAuthGuard] },
      { path: 'trainer-portal/users', component: UsersTrainerPortalComponent, canActivate: [TrainerAuthGuard] },
      { path: 'trainer-portal/users-edit/:id', component: UsersEditTrainerPortalComponent, canActivate: [TrainerAuthGuard] },
      { path: 'trainer-portal/applications', component: ApplicationsTrainerPortalComponent, canActivate: [TrainerAuthGuard] },
      { path: 'trainer-portal/studentsInCourse', component: StudentsInCourseTrainerPortalComponent, canActivate: [TrainerAuthGuard] },

      { path: '**', redirectTo: '' }
    ])
  ],
  providers: [
    AuthGuard,
    TrainerAuthGuard,
    StudentAuthGuard,
    AlertService,
    AuthenticationService,
    UserService,
    SeasonService,
    SemesterService,
    ApplicationService,
    CourseService,
    HomeworkService,
    LectureService,
    StudentsInCourseService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
],
  bootstrap: [AppComponent]
})
export class AppModule {}
