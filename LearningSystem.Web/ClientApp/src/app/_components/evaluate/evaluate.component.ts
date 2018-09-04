import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Application, Evaluation } from '../../_models';
import { Router, ActivatedRoute } from '@angular/router';
import { HomeworkService } from '../../_services';
import { HomeworkAssignment } from '../../_models/homeworkAssignment';

@Component({
  selector: 'evaluate',
  templateUrl: './evaluate.component.html'
})
export class EvaluateComponent {
  private model: Evaluation = new Evaluation();
  private homeworkAssignmentId: number;
  private homeworkSubmissionId: number;

  constructor(private route: ActivatedRoute, private homeworkService: HomeworkService, private router: Router) {
    this.route.params.subscribe(params => {
      this.homeworkAssignmentId = parseInt(params['id']);

      this.homeworkService.getRandonHomeworkSubmissionId(this.homeworkAssignmentId).subscribe(data => {
        this.homeworkSubmissionId = data;
      });
    });
  }

  downloadHomework() {
    this.homeworkService.downloadHomework(this.homeworkSubmissionId).subscribe(data => {
      var blob = new Blob([data], { type: 'text/plain' });
      var url = window.URL.createObjectURL(blob);
      window.open(url);
    }, error => {
      console.log(error);
      });
  }

  onSubmit() {
    this.model.homeworkSubmissionId = this.homeworkSubmissionId;
    this.homeworkService.submitHomeworkEvaluation(this.model).subscribe(data => {
      // TODO: Test whether the page is refreshed
      this.router.navigate(["/evaluate/" + this.homeworkAssignmentId]);
    });
  }
}
