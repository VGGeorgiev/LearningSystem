import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Semester } from '../../_models/semester';
import { SemesterService } from '../../_services/semester.service';
import { CourseService } from '../../_services/course.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseDetail } from '../../_models';
import { DomSanitizer } from '@angular/platform-browser';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { homedir } from 'os';
import { HomeworkAssignment } from '../../_models/homeworkAssignment';
import { AlertsService } from 'angular-alert-module';

@Component({
  selector: 'course',
  templateUrl: './course.component.html'
})
export class CourseComponent {
  private course: CourseDetail = new CourseDetail();
  private now: Date = new Date();
  private id: number;

  constructor(private courseService: CourseService,
    private route: ActivatedRoute,
    private sanitizer: DomSanitizer,
    private router: Router,
    private http: HttpClient,
    private alerts: AlertsService) {
    this.route.params.subscribe(params => {
      this.id = params['id'];
      this.courseService.GetCourse(this.id).subscribe(data => {
        this.now = new Date();
        this.course = data;
        this.course.lectures.forEach(x => x.homeworkAssignments.forEach(h => h.deadline = new Date(h.deadline)));
        this.course.lectures.forEach(x => x.safeVideoUrl = this.sanitizer.bypassSecurityTrustResourceUrl(x.videoUrl));
      });
    });
  }

  fileChange(event, homework: HomeworkAssignment) {
    let fileList: FileList = event.target.files;
    if (fileList.length > 0) {
      let file: File = fileList[0];
      let formData: FormData = new FormData();
      formData.append('file', file, file.name);
      let headers = new HttpHeaders();
      /** In Angular 5, including the header Content-Type can invalidate your request */
      headers.append('Content-Type', 'multipart/form-data');
      headers.append('Accept', 'application/json');
      // TODO: Move call to homework.service.ts
      this.http.post(`${environment.apiBaseUrl}/homework/upload/${homework.id}`, formData, { headers: headers })
        .subscribe(data => {
          homework.hasUserSubmission = true;
          this.alerts.setMessage('Successfuly submitted homework!', 'success');
        }, error => {
          console.log(error);
          this.alerts.setMessage('Failed to submit homework!', 'error');
        });
    }
  }
}
