import { Component, OnInit } from '@angular/core';
import { SeasonService } from '../../../_services';
import { SeasonInput } from '../../../_models';
import { AlertsService } from 'angular-alert-module';

@Component({
  selector: 'seasons-portal-component',
  templateUrl: './seasons.trainer-portal.component.html'
})
export class SeasonsTrainerPortalComponent implements OnInit {
  private seasons: SeasonInput[];
  constructor(private seasonService: SeasonService, private alerts: AlertsService) { }

  ngOnInit() {
    this.getSeasons();
  }

  getSeasons() {
    this.seasonService.GetAll().subscribe(data => {
      this.seasons = data;
    });
  }

  deleteSeason(id: number) {
    this.seasonService.deleteSeason(id).subscribe(x => {
      this.getSeasons();
      this.alerts.setMessage("Successfuly delete season!", "success");
    });
  }
}
