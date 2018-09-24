import { Component } from '@angular/core';
import { SeasonService } from '../../../_services';
import { SeasonInput } from '../../../_models';
import { AlertsService } from 'angular-alert-module';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'seasons-edit-trainer-portal-component',
  templateUrl: './seasons-edit.trainer-portal.component.html'
})
export class SeasonsEditTrainerPortalComponent {
  public season: SeasonInput = new SeasonInput();
  private id: number;

  constructor(
    private seasonService: SeasonService,
    private alert: AlertsService,
    private route: ActivatedRoute,
    private router: Router) {

  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
      this.seasonService.GetById(this.id).subscribe(data => {
        this.season = data;
      });
    });
  }

  onSubmit() {
    this.seasonService.editSeason(this.id, this.season).subscribe(data => {
      this.router.navigate(['/trainer-portal/seasons']);
      this.alert.setMessage('Successfuly editted season!', 'success');
    }, error => {
      this.alert.setMessage('Error editting season!', 'error');
    });
  }
}
