import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { CourseDetail } from '../_models/course';

@Injectable()
export class CourseService {
  constructor(private http: HttpClient) { }

  GetCourse(id: number) {
    return this.http.get<CourseDetail>(`${environment.apiBaseUrl}/courses/get/${id}`);
  }
}
