import { Component, OnInit } from '@angular/core';
import { SeasonService, SemesterService, StudentsInCourseService } from '../../../_services';
import { SeasonInput, Semester, SemesterInput, CourseInput, Season, Course } from '../../../_models';
import { AlertsService } from 'angular-alert-module';
import { Router } from '@angular/router';
import { CourseService } from '../../../_services/course.service';

@Component({
  selector: 'studentsInCourse-create-trainer-portal-component',
  templateUrl: './studentsInCourse.trainer-portal.component.html'
})
export class StudentsInCourseTrainerPortalComponent {
  public courses: Course[];
  public seasons: SeasonInput[];
  public model = { seasonId: 0, courseId: 0 };

  constructor(
    private courseService: CourseService,
    private seasonService: SeasonService,
    private studentsInCourseService: StudentsInCourseService,
    private alert: AlertsService) { }

  onSubmit() {
    this.studentsInCourseService.entollStudentsInCourse(this.model).subscribe(x => {
      this.alert.setMessage('Successfuly enrolled students in course!', 'success');
    }, error => {
      this.alert.setMessage('Error enrolling students in course!', 'error');
    });
  }

  ngOnInit() {
    this.courseService.GetAll().subscribe(data => {
      this.courses = data;
    });

    this.seasonService.GetAll().subscribe(data => {
      this.seasons = data;
    });
  }
}
