import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { Application } from '../_models';

@Injectable()
export class ApplicationService {
  constructor(private http: HttpClient) { }

  sendApplication(application: Application) {
    let formData: FormData = new FormData();
    formData.append('documents', application.documents, application.documents.name);
    formData.append('firstName', application.firstName);
    formData.append('lastName', application.lastName);
    formData.append('highSchoolGrade', application.highSchoolGrade.toString());
    formData.append('userId', application.userId.toString());
    formData.append('seasonId', application.seasonId.toString());

    let headers = new HttpHeaders();
    headers.append('Content-Type', 'multipart/form-data');
    headers.append('Accept', 'application/json');
    return this.http.post(`${environment.apiBaseUrl}/application/add`, formData, { headers: headers });
  }
}
