import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { Application } from '../_models';

@Injectable()
export class ApplicationService {
  constructor(private http: HttpClient) { }

  sendApplication(application: Application) {
    return this.http.post(`${environment.apiBaseUrl}/application/add`, application);
  }
}
