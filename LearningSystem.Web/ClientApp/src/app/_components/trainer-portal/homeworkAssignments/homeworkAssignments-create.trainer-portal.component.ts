import { Component, OnInit } from '@angular/core';
import { Course } from '../../../_models';
import { AlertsService } from 'angular-alert-module';
import { Router } from '@angular/router';
import { CourseService } from '../../../_services/course.service';
import { LectureInput, Lecture } from '../../../_models/lecture';
import { LectureService } from '../../../_services/lecture.service';
import { HomeworkAssignmentInput } from '../../../_models/homeworkAssignment';
import { HomeworkService } from '../../../_services';

@Component({
  selector: 'homeworkAssignments-create-trainer-portal-component',
  templateUrl: './homeworkAssignments-create.trainer-portal.component.html'
})
export class HomeworkAssignmentsCreateTrainerPortalComponent {
  public homeworkAssignment: HomeworkAssignmentInput = new HomeworkAssignmentInput();
  public lectures: LectureInput[];

  constructor(private homeworkService: HomeworkService,
    private lectureService: LectureService,
    private alert: AlertsService,
    private router: Router) { }

  onSubmit() {
    this.homeworkService.sendAssignment(this.homeworkAssignment).subscribe(x => {
      this.router.navigate(['/trainer-portal/homework-assignments']);
      this.alert.setMessage('Successfuly inserted homework assignment!', 'success');
    }, error => {
      this.alert.setMessage('Error inserting homework assignment!', 'error');
    });
  }

  ngOnInit() {
    this.lectureService.GetAll().subscribe(data => {
      this.lectures = data;
    });
  }
}
