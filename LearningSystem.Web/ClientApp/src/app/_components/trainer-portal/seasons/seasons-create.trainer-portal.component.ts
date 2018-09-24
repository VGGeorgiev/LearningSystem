import { Component, OnInit } from '@angular/core';
import { SeasonService } from '../../../_services';
import { SeasonInput } from '../../../_models';
import { AlertsService } from 'angular-alert-module';
import { Router } from '@angular/router';

@Component({
  selector: 'seasons-create-trainer-portal-component',
  templateUrl: './seasons-create.trainer-portal.component.html'
})
export class SeasonsCreateTrainerPortalComponent {
  public season: SeasonInput = new SeasonInput();

  constructor(private seasonService: SeasonService, private alert: AlertsService, private router: Router) {

  }

  onSubmit() {
    this.seasonService.sendSeason(this.season).subscribe(x => {
      this.router.navigate(['/trainer-portal/seasons']);
      this.alert.setMessage('Successfuly inserted season!', 'success');
    }, error => {
      this.alert.setMessage('Error inserting season!', 'error');
    });
  }
}
