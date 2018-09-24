import { Component, OnInit } from '@angular/core';
import { UserService, ApplicationService } from '../../../_services';
import { UserInput, Application } from '../../../_models';
import { AlertsService } from 'angular-alert-module';

@Component({
  selector: 'applications-portal-component',
  templateUrl: './applications.trainer-portal.component.html'
})
export class ApplicationsTrainerPortalComponent implements OnInit {
  private applications: Application[];
  constructor(private applicationService: ApplicationService, private alerts: AlertsService) { }

  ngOnInit() {
    this.getApplications();
  }

  getApplications() {
    this.applicationService.getAll().subscribe(data => {
      this.applications = data;
    });
  }

  approveApplication(id: number) {
    this.applicationService.approveApplication(id).subscribe(x => {
      this.getApplications();
    });
  }
}
