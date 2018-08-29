import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Semester } from '../../_models/semester';
import { SemesterService } from '../../_services/semester.service';
import { CourseService } from '../../_services/course.service';
import { ActivatedRoute } from '@angular/router';
import { CourseDetail } from '../../_models';

@Component({
  selector: 'course',
  templateUrl: './course.component.html'
})
export class CourseComponent {
  private course: CourseDetail = new CourseDetail();

  constructor(private courseService: CourseService, private route: ActivatedRoute) {
    this.route.params.subscribe(params => {
      var id = params['id'];
      this.courseService.GetCourse(id).subscribe(data => {
        this.course = data;
      });
    });
  }
}
