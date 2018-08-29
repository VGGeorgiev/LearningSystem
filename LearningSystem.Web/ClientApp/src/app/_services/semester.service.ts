import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { Semester } from '../_models/semester';

@Injectable()
export class SemesterService {
  constructor(private http: HttpClient) { }

  GetSemestersWithCourses() {
    return this.http.get<Semester[]>(`${environment.apiBaseUrl}/semesters`);
  }
}
