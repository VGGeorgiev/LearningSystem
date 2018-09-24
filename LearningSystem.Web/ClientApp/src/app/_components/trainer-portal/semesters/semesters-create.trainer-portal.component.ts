import { Component, OnInit } from '@angular/core';
import { SeasonService, SemesterService } from '../../../_services';
import { SeasonInput, Semester, SemesterInput } from '../../../_models';
import { AlertsService } from 'angular-alert-module';
import { Router } from '@angular/router';

@Component({
  selector: 'semesters-create-trainer-portal-component',
  templateUrl: './semesters-create.trainer-portal.component.html'
})
export class SemestersCreateTrainerPortalComponent {
  public semester: SemesterInput = new SemesterInput();

  constructor(private semesterService: SemesterService,
    private alert: AlertsService,
    private router: Router) {

  }

  onSubmit() {
    this.semesterService.send(this.semester).subscribe(x => {
      this.router.navigate(['/trainer-portal/semesters']);
      this.alert.setMessage('Successfuly inserted semester!', 'success');
    }, error => {
      this.alert.setMessage('Error inserting semester!', 'error');
    });
  }
}
