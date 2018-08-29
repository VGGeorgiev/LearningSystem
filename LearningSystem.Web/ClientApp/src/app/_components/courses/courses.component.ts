import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Semester } from '../../_models/semester';
import { SemesterService } from '../../_services/semester.service';

@Component({
  selector: 'courses',
  templateUrl: './courses.component.html'
})
export class CoursesComponent {
  public semesters: Semester[];

  constructor(private semestersService: SemesterService) {
    this.semestersService.GetSemestersWithCourses().subscribe(data => {
      this.semesters = data;
    });
  }
}
