import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { Semester, SemesterInput } from '../_models/semester';

@Injectable()
export class SemesterService {
  constructor(private http: HttpClient) { }

  GetSemestersWithCourses() {
    return this.http.get<Semester[]>(`${environment.apiBaseUrl}/semesters`);
  }
  
  GetAll() {
    return this.http.get<SemesterInput[]>(`${environment.apiBaseUrl}/semesters/getAll`);
  }

  GetById(id: number) {
    return this.http.get<SemesterInput>(`${environment.apiBaseUrl}/semesters/get/${id}`);
  }

  send(semester: SemesterInput) {
    return this.http.post<SemesterInput>(`${environment.apiBaseUrl}/semesters/insert`, semester);
  }

  edit(id: number, semester: SemesterInput) {
    return this.http.put<SemesterInput>(`${environment.apiBaseUrl}/semesters/edit/${id}`, semester)
  }

  delete(id: number) {
    return this.http.delete(`${environment.apiBaseUrl}/semesters/delete/${id}`);
  }
}
