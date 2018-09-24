import { Component } from '@angular/core';
import { SeasonService, SemesterService, HomeworkService } from '../../../_services';
import { SeasonInput, Semester, SemesterInput, CourseInput, Course } from '../../../_models';
import { AlertsService } from 'angular-alert-module';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';
import { CourseService } from '../../../_services/course.service';
import { LectureInput } from '../../../_models/lecture';
import { LectureService } from '../../../_services/lecture.service';
import { HomeworkAssignmentInput } from '../../../_models/homeworkAssignment';

@Component({
  selector: 'homeworkAssignments-edit-trainer-portal-component',
  templateUrl: './homeworkAssignments-edit.trainer-portal.component.html'
})
export class HomeworkAssignmentsEditTrainerPortalComponent {
  public homeworkAssignment: HomeworkAssignmentInput = new HomeworkAssignmentInput();
  private id: number;
  public lectures: LectureInput[];

  constructor(
    private lectureService: LectureService,
    private homeworkService: HomeworkService,
    private alert: AlertsService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
      this.homeworkService.getAssignmentById(this.id).subscribe(data => {
        this.homeworkAssignment = data;
      });

      this.lectureService.GetAll().subscribe(data => {
        this.lectures = data;
      });
    });
  }

  onSubmit() {
    this.homeworkService.editAssignment(this.homeworkAssignment).subscribe(data => {
      this.router.navigate(['/trainer-portal/homework-assignments']);
      this.alert.setMessage('Successfuly editted homework assignment!', 'success');
    }, error => {
      this.alert.setMessage('Error editting homework assignment!', 'error');
    });
  }
}
