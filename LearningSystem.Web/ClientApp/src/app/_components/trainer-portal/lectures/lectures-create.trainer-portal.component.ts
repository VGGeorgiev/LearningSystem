import { Component, OnInit } from '@angular/core';
import { Course } from '../../../_models';
import { AlertsService } from 'angular-alert-module';
import { Router } from '@angular/router';
import { CourseService } from '../../../_services/course.service';
import { LectureInput } from '../../../_models/lecture';
import { LectureService } from '../../../_services/lecture.service';

@Component({
  selector: 'lectures-create-trainer-portal-component',
  templateUrl: './lectures-create.trainer-portal.component.html'
})
export class LecturesCreateTrainerPortalComponent {
  public lecture: LectureInput = new LectureInput();
  public courses: Course[];

  constructor(private courseService: CourseService,
    private lectureService: LectureService,
    private alert: AlertsService,
    private router: Router) { }

  onSubmit() {
    this.lectureService.send(this.lecture).subscribe(x => {
      this.router.navigate(['/trainer-portal/lectures']);
      this.alert.setMessage('Successfuly inserted lecture!', 'success');
    }, error => {
      this.alert.setMessage('Error inserting lecture!', 'error');
    });
  }

  ngOnInit() {
    this.courseService.GetAll().subscribe(data => {
      this.courses = data;
    });
  }
}
