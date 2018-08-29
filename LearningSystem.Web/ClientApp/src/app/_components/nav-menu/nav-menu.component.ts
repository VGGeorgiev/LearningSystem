import { Component } from '@angular/core';
import { AuthenticationService } from '../../_services';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(private authenticationService: AuthenticationService, private router: Router) {

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
