import { Component } from '@angular/core';
import { AuthenticationService } from '../../_services';
import { User, Season } from '../../_models';
import { SeasonService } from '../../_services/season.service';
import { AlertsService } from 'angular-alert-module';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public currentUser: User;
  public seasons: Season[];

  constructor(
    private authenticationService: AuthenticationService,
    private seasonService: SeasonService,
    private alerts: AlertsService) {
    this.currentUser = this.authenticationService.getCurrentUser();
    this.seasonService.GetAvailable().subscribe(data => {
      this.seasons = data;
    });
  }
}
