import { Component, OnInit } from '@angular/core';
import { SeasonService, SemesterService } from '../../../_services';
import { SeasonInput, Semester, SemesterInput } from '../../../_models';
import { AlertsService } from 'angular-alert-module';

@Component({
  selector: 'semesters-portal-component',
  templateUrl: './semesters.trainer-portal.component.html'
})
export class SemestersTrainerPortalComponent implements OnInit {
  private semesters: SemesterInput[];
  constructor(private semesterService: SemesterService, private alerts: AlertsService) { }

  ngOnInit() {
    this.getSemesters();
  }

  getSemesters() {
    this.semesterService.GetAll().subscribe(data => {
      this.semesters = data;
    });
  }

  deleteSemester(id: number) {
    this.semesterService.delete(id).subscribe(x => {
      this.getSemesters();
      this.alerts.setMessage("Successfuly delete semester!", "success");
    });
  }
}
