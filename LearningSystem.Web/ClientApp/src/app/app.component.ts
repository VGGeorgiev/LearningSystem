import { Component } from '@angular/core';
import { AlertsService } from 'angular-alert-module';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';

  constructor(private alerts: AlertsService) {
  }

  ngOnInit() {
    this.alerts.setDefaults('timeout', 3);
  }
}
