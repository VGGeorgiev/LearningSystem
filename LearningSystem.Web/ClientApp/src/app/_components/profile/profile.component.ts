import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthenticationService, UserService } from '../../_services';
import { User, UserInCourse } from '../../_models';
import { AlertsService } from 'angular-alert-module';

@Component({
  selector: 'profile',
  templateUrl: 'profile.component.html'
})
export class ProfileComponent {
  username: string;
  user: User = new User();
  userInCourses: UserInCourse[];
  isMyProfile: boolean;

  constructor(private route: ActivatedRoute,
    private authenticationService: AuthenticationService,
    private userService: UserService,
    private alerts: AlertsService) {
    
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.username = params['username'];
      if (!this.username) {
        this.username = this.authenticationService.getCurrentUser().username;
      }

      if (this.username == this.authenticationService.getCurrentUser().username) {
        this.isMyProfile = true;
      }

      this.userService.getByUsername(this.username).subscribe(data => {
        this.user = data;

        this.userService.getUserInCourses(this.user.id).subscribe(data => {
          this.userInCourses = data;
        });
      });

    });
  }

  changeGrade(userInCourse: UserInCourse) {
    this.userService.changeGrade(userInCourse).subscribe(data => {
      this.alerts.setMessage('Successfully updated grade', 'success');
    });
  }
}
