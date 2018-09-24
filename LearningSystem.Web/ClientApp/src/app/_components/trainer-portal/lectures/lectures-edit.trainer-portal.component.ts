import { Component } from '@angular/core';
import { SeasonService, SemesterService } from '../../../_services';
import { SeasonInput, Semester, SemesterInput, CourseInput, Course } from '../../../_models';
import { AlertsService } from 'angular-alert-module';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';
import { CourseService } from '../../../_services/course.service';
import { LectureInput } from '../../../_models/lecture';
import { LectureService } from '../../../_services/lecture.service';

@Component({
  selector: 'lectures-edit-trainer-portal-component',
  templateUrl: './lectures-edit.trainer-portal.component.html'
})
export class LecturesEditTrainerPortalComponent {
  public lecture: LectureInput = new LectureInput();
  private id: number;
  public courses: Course[];

  constructor(
    private lectureService: LectureService,
    private courseService: CourseService,
    private alert: AlertsService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
      this.lectureService.GetById(this.id).subscribe(data => {
        this.lecture = data;
      });

      this.courseService.GetAll().subscribe(data => {
        this.courses = data;
      });
    });
  }

  onSubmit() {
    this.lectureService.edit(this.id, this.lecture).subscribe(data => {
      this.router.navigate(['/trainer-portal/lectures']);
      this.alert.setMessage('Successfuly editted lecture!', 'success');
    }, error => {
      this.alert.setMessage('Error editting lecture!', 'error');
    });
  }
}
