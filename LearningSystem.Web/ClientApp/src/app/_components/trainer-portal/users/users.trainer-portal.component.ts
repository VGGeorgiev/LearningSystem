import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../_services';
import { UserInput } from '../../../_models';
import { AlertsService } from 'angular-alert-module';

@Component({
  selector: 'users-portal-component',
  templateUrl: './users.trainer-portal.component.html'
})
export class UsersTrainerPortalComponent implements OnInit {
  private users: UserInput[];
  constructor(private userService: UserService, private alerts: AlertsService) { }

  ngOnInit() {
    this.userService.getAll().subscribe(data => {
      console.log(data);
      this.users = data;
    });
  }
}
