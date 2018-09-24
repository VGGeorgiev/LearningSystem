import { Component } from '@angular/core';
import { SeasonService, SemesterService, UserService } from '../../../_services';
import { SeasonInput, Semester, SemesterInput, CourseInput, Course, UserInput } from '../../../_models';
import { AlertsService } from 'angular-alert-module';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';
import { CourseService } from '../../../_services/course.service';
import { LectureInput } from '../../../_models/lecture';
import { LectureService } from '../../../_services/lecture.service';

@Component({
  selector: 'users-edit-trainer-portal-component',
  templateUrl: './users-edit.trainer-portal.component.html'
})
export class UsersEditTrainerPortalComponent {
  public user: UserInput = new UserInput();
  private id: number;

  constructor(
    private userService: UserService,
    private alert: AlertsService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
      this.userService.getById(this.id).subscribe(data => {
        this.user = data;
      });
    });
  }

  onSubmit() {
    this.userService.updateType(this.user).subscribe(data => {
      this.router.navigate(['/trainer-portal/users']);
      this.alert.setMessage('Successfuly editted user!', 'success');
    }, error => {
      this.alert.setMessage('Error editting user!', 'error');
    });
  }
}
