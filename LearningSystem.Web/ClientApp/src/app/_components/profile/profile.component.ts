import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthenticationService, UserService } from '../../_services';
import { User, UserDetail } from '../../_models';
import { Feedback } from '../../_models/feedback';

@Component({
  selector: 'profile',
  templateUrl: 'profile.component.html'
})
export class ProfileComponent {
  username: string;
  user: UserDetail;
  model: Feedback = new Feedback();
  isMyProfile: boolean;

  constructor(private route: ActivatedRoute, private authenticationService: AuthenticationService, private userService: UserService) {
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
      });
    });
  }

  onSubmit() {
    this.model.userId = this.user.id;
    this.userService.sendFeedback(this.model).subscribe(data => {
      this.user.feedbacks.push(data);
    });
  }
}
