import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { Evaluation } from '../_models';

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
}
