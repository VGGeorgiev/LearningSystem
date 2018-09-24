import { Component } from '@angular/core';
import { SeasonService, SemesterService } from '../../../_services';
import { SeasonInput, Semester, SemesterInput } from '../../../_models';
import { AlertsService } from 'angular-alert-module';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'semesters-edit-trainer-portal-component',
  templateUrl: './semesters-edit.trainer-portal.component.html'
})
export class SemestersEditTrainerPortalComponent {
  public semester: SemesterInput = new SemesterInput();
  private id: number;

  constructor(
    private semesterService: SemesterService,
    private alert: AlertsService,
    private route: ActivatedRoute,
    private router: Router) {

  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
      this.semesterService.GetById(this.id).subscribe(data => {
        this.semester = data;
      });
    });
  }

  onSubmit() {
    this.semesterService.edit(this.id, this.semester).subscribe(data => {
      this.router.navigate(['/trainer-portal/semesters']);
      this.alert.setMessage('Successfuly editted semester!', 'success');
    }, error => {
      this.alert.setMessage('Error editting semester!', 'error');
    });
  }
}
