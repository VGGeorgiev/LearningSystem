import { Component, OnInit } from '@angular/core';
import { SeasonService, SemesterService } from '../../../_services';
import { SeasonInput, Semester, SemesterInput, CourseInput } from '../../../_models';
import { AlertsService } from 'angular-alert-module';
import { CourseService } from '../../../_services/course.service';
import { LectureInput } from '../../../_models/lecture';
import { LectureService } from '../../../_services/lecture.service';

@Component({
  selector: 'lectures-portal-component',
  templateUrl: './lectures.trainer-portal.component.html'
})
export class LecturesTrainerPortalComponent implements OnInit {
  private lectures: LectureInput[];
  constructor(private lectureService: LectureService, private alerts: AlertsService) { }

  ngOnInit() {
    this.getLectures();
  }

  getLectures() {
    this.lectureService.GetAll().subscribe(data => {
      this.lectures = data;
    });
  }

  deleteLecture(id: number) {
    this.lectureService.delete(id).subscribe(x => {
      this.getLectures();
      this.alerts.setMessage("Successfuly delete lecture!", "success");
    });
  }
}
