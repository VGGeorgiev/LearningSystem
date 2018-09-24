import { Component } from '@angular/core';
import { SeasonService, SemesterService } from '../../../_services';
import { SeasonInput, Semester, SemesterInput, CourseInput } from '../../../_models';
import { AlertsService } from 'angular-alert-module';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';
import { CourseService } from '../../../_services/course.service';

@Component({
  selector: 'courses-edit-trainer-portal-component',
  templateUrl: './courses-edit.trainer-portal.component.html'
})
export class CoursesEditTrainerPortalComponent {
  public course: CourseInput = new CourseInput();
  private id: number;
  public semesters: SemesterInput[];

  constructor(
    private courseService: CourseService,
    private semesterService: SemesterService,
    private alert: AlertsService,
    private route: ActivatedRoute,
    private router: Router) {

  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
      this.courseService.GetById(this.id).subscribe(data => {
        this.course = data;
      });

      this.semesterService.GetAll().subscribe(data => {
        this.semesters = data;
      });
    });
  }

  onSubmit() {
    this.courseService.edit(this.id, this.course).subscribe(data => {
      this.router.navigate(['/trainer-portal/courses']);
      this.alert.setMessage('Successfuly editted course!', 'success');
    }, error => {
      this.alert.setMessage('Error editting course!', 'error');
    });
  }
}
