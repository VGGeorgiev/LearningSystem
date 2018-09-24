import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthenticationService, UserService } from '../_services';
import { UserType } from '../_models';
import { map } from 'rxjs/operators';

@Injectable()
export class StudentAuthGuard implements CanActivate {

  constructor(private router: Router, private userService: UserService, private authService: AuthenticationService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    var userId = this.authService.getCurrentUser().id;
    return this.userService.getById(userId).pipe(map(user => {
      if (user.type == UserType.Student || user.type == UserType.Trainer) {
        return true;
      }

      return false;
    }));
  }
}
