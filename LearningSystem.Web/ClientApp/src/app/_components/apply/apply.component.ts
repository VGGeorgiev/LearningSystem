import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { Season, Application } from '../../_models';
import { SeasonService, AuthenticationService } from '../../_services';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { ApplicationService } from '../../_services/application.service';

@Component({
  selector: 'apply-component',
  templateUrl: './apply.component.html'
})
export class ApplyComponent {
  private season: Season = { name: "", startDate: new Date(), studentsLimit: 0, id: 0, isUserApplied: false };
  private model: Application = new Application();

  constructor(private seasonService: SeasonService,
    private applicationService: ApplicationService,
    private authenticationService: AuthenticationService,
    private router: Router,
    private route: ActivatedRoute,
    private cd: ChangeDetectorRef) {  
    this.route.params.subscribe(params => {
      var id = parseInt(params['id']);
      this.seasonService.GetById(id).subscribe(data => {
        this.season = data;
      });
    });
  }

  onFileChange(event) {
    if (event.target.files && event.target.files.length) {
      let file: File = event.target.files[0];
      this.model.documents = file;
    }
  }

  onSubmit() {
    this.model.seasonId = this.season.id;
    this.model.userId = this.authenticationService.getCurrentUser().id;

    this.applicationService.sendApplication(this.model).subscribe(x => {
      this.router.navigate(['/applied']);
    }, error => console.log(error));
  }
}
