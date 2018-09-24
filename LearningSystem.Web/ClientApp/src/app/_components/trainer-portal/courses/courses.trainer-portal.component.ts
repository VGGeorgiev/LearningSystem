import { Component, OnInit } from '@angular/core';
import { SeasonService, SemesterService } from '../../../_services';
import { SeasonInput, Semester, SemesterInput, CourseInput } from '../../../_models';
import { AlertsService } from 'angular-alert-module';
import { CourseService } from '../../../_services/course.service';

@Component({
  selector: 'courses-portal-component',
  templateUrl: './courses.trainer-portal.component.html'
})
export class CoursesTrainerPortalComponent implements OnInit {
  private courses: CourseInput[];
  constructor(private coursesService: CourseService, private alerts: AlertsService) { }

  ngOnInit() {
    this.getCourses();
  }

  getCourses() {
    this.coursesService.GetAll().subscribe(data => {
      this.courses = data;
    });
  }

  deleteCourse(id: number) {
    this.coursesService.delete(id).subscribe(x => {
      this.getCourses();
      this.alerts.setMessage("Successfuly delete course!", "success");
    });
  }
}
