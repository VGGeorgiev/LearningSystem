import { Component, OnInit } from '@angular/core';
import { SeasonService, SemesterService, HomeworkService } from '../../../_services';
import { SeasonInput, Semester, SemesterInput, CourseInput } from '../../../_models';
import { AlertsService } from 'angular-alert-module';
import { CourseService } from '../../../_services/course.service';
import { LectureInput } from '../../../_models/lecture';
import { LectureService } from '../../../_services/lecture.service';
import { HomeworkAssignmentInput } from '../../../_models/homeworkAssignment';

@Component({
  selector: 'homeworkAssignments-portal-component',
  templateUrl: './homeworkAssignments.trainer-portal.component.html'
})
export class HomeworkAssignmentsTrainerPortalComponent implements OnInit {
  private homeworkAssignments: HomeworkAssignmentInput[];
  constructor(private homeworkService: HomeworkService, private alerts: AlertsService) { }

  ngOnInit() {
    this.getHomeworkAssignments();
  }

  getHomeworkAssignments() {
    this.homeworkService.getAllAssignments().subscribe(data => {
      this.homeworkAssignments = data;
    });
  }

  deleteHomeworkAssignment(id: number) {
    this.homeworkService.deleteAssignment(id).subscribe(x => {
      this.getHomeworkAssignments();
      this.alerts.setMessage("Successfuly delete homework assignment!", "success");
    });
  }
}
