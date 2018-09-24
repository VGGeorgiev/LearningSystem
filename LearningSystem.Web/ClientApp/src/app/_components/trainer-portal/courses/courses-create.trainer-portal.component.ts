import { Component, OnInit } from '@angular/core';
import { SeasonService, SemesterService } from '../../../_services';
import { SeasonInput, Semester, SemesterInput, CourseInput } from '../../../_models';
import { AlertsService } from 'angular-alert-module';
import { Router } from '@angular/router';
import { CourseService } from '../../../_services/course.service';

@Component({
  selector: 'courses-create-trainer-portal-component',
  templateUrl: './courses-create.trainer-portal.component.html'
})
export class CoursesCreateTrainerPortalComponent {
  public course: CourseInput = new CourseInput();
  public semesters: SemesterInput[];

  constructor(private courseService: CourseService,
    private semesterService: SemesterService,
    private alert: AlertsService,
    private router: Router) { }

  onSubmit() {
    this.courseService.send(this.course).subscribe(x => {
      this.router.navigate(['/trainer-portal/courses']);
      this.alert.setMessage('Successfuly inserted course!', 'success');
    }, error => {
      this.alert.setMessage('Error inserting course!', 'error');
    });
  }

  ngOnInit() {
    this.semesterService.GetAll().subscribe(data => {
      this.semesters = data;
    });
  }
}
