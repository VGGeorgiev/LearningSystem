import { Component } from '@angular/core';
import { AuthenticationService } from '../../_services';
import { Router } from '@angular/router';
import { User } from '../../_models';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  currentUser: User;
  isExpanded = false;

  constructor(private authenticationService: AuthenticationService, private router: Router) {
    this.currentUser = this.authenticationService.getCurrentUser();
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout() {
    this.authenticationService.logout();

    this.router.navigate(['/login']);
  }

  isLoggedIn() {
    return this.authenticationService.isLoggedIn();
  }
}
