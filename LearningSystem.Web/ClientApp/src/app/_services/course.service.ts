import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { CourseDetail, CourseInput } from '../_models/course';

@Injectable()
export class CourseService {
  constructor(private http: HttpClient) { }

  GetCourse(id: number) {
    return this.http.get<CourseDetail>(`${environment.apiBaseUrl}/courses/get/${id}`);
  }
  
  GetAll() {
    return this.http.get<CourseInput[]>(`${environment.apiBaseUrl}/courses/getAll`);
  }

  GetById(id: number) {
    return this.http.get<CourseInput>(`${environment.apiBaseUrl}/courses/get/${id}`);
  }

  send(course: CourseInput) {
    return this.http.post<CourseInput>(`${environment.apiBaseUrl}/courses/insert`, course);
  }

  edit(id: number, course: CourseInput) {
    return this.http.put<CourseInput>(`${environment.apiBaseUrl}/courses/edit/${id}`, course)
  }

  delete(id: number) {
    return this.http.delete(`${environment.apiBaseUrl}/courses/delete/${id}`);
  }
}
