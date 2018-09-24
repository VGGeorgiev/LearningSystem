import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';

@Injectable()
export class StudentsInCourseService {
  constructor(private http: HttpClient) { }

  entollStudentsInCourse(model) {
    return this.http.post(`${environment.apiBaseUrl}/studentsInCourse/enroll`, model);
  }
}
