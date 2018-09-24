import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { Evaluation } from '../_models';
import { HomeworkAssignmentInput } from '../_models/homeworkAssignment';

@Injectable()
export class HomeworkService {
  constructor(private http: HttpClient) { }

  getRandonHomeworkSubmissionId(homeworkAssignmentId: number) {
    return this.http.get<number>(`${environment.apiBaseUrl}/homework/getRandomHomeworkId/${homeworkAssignmentId}`);
  }

  downloadHomework(homeworkSubmissionId: number) {
    return this.http.get(`${environment.apiBaseUrl}/homework/download/${homeworkSubmissionId}`, { 'responseType': 'blob' });
  }

  submitHomeworkEvaluation(evaluation: Evaluation) {
    return this.http.post(`${environment.apiBaseUrl}/homework/evaluate`, evaluation);
  }

  getAllAssignments() {
    return this.http.get<HomeworkAssignmentInput[]>(`${environment.apiBaseUrl}/homework/getAllAssignments`);
  }

  getAssignmentById(id: number) {
    return this.http.get<HomeworkAssignmentInput>(`${environment.apiBaseUrl}/homework/getAssignmentById/${id}`);
  } 

  editAssignment(homeworkAssignment: HomeworkAssignmentInput) {
    return this.http.put(`${environment.apiBaseUrl}/homework/editAssignment`, homeworkAssignment);
  }

  deleteAssignment(id: number) {
    return this.http.delete(`${environment.apiBaseUrl}/homework/deleteAssignment/${id}`);
  }

  sendAssignment(homeworkAssignment: HomeworkAssignmentInput) {
    return this.http.post(`${environment.apiBaseUrl}/homework/insertAssignment`, homeworkAssignment);
  }
}
