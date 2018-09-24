import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { LectureInput } from '../_models/lecture';

@Injectable()
export class LectureService {
  constructor(private http: HttpClient) { }
  
  GetAll() {
    return this.http.get<LectureInput[]>(`${environment.apiBaseUrl}/lectures/getAll`);
  }

  GetById(id: number) {
    return this.http.get<LectureInput>(`${environment.apiBaseUrl}/lectures/get/${id}`);
  }

  send(lecture: LectureInput) {
    return this.http.post<LectureInput>(`${environment.apiBaseUrl}/lectures/insert`, lecture);
  }

  edit(id: number, lecture: LectureInput) {
    return this.http.put<LectureInput>(`${environment.apiBaseUrl}/lectures/edit/${id}`, lecture);
  }

  delete(id: number) {
    return this.http.delete(`${environment.apiBaseUrl}/lectures/delete/${id}`);
  }
}
