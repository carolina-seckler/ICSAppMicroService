import { Component, OnInit } from '@angular/core';
import { ActivityModel } from 'src/app/models/activity';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { IncidentService } from 'src/app/services/incident.service';
import { SectionService } from 'src/app/services/section.service';
import { ActivityService } from 'src/app/services/activity.service';
import { StatusService } from 'src/app/services/status.service';

@Component({
  selector: 'app-criar-atividade',
  templateUrl: './criar-atividade.component.html',
  styleUrls: ['./criar-atividade.component.scss']
})
export class CriarAtividadeComponent implements OnInit {

  activityModel = new ActivityModel();
  formActivity: FormGroup;
  optIncident = [];
  optStatus = [];
  optSection = [];

  constructor(private fb: FormBuilder,
              private activityService: ActivityService,
              private incidentService: IncidentService,
              private statusService: StatusService,
              private sectionService: SectionService) { }

  ngOnInit(): void {

    this.incidentService.getAll().subscribe(result => {
      this.optIncident = result;
    }, e => {
    });

    this.statusService.getAll().subscribe(result => {
      this.optStatus = result;
    }, e => {
    });

    this.sectionService.getAll().subscribe(result => {
      this.optSection = result;
    }, e => {
    });

    this.formActivity = this.fb.group({
      description: ['', Validators.required],
      idIncident: ['', Validators.required],
      idStatus: ['', Validators.required],
      idSection: ['', Validators.required]
    });
  }

  salvar(): void{
    if (!this.formActivity) {
      return;
    }
    this.activityModel.description = this.formActivity.get('description').value;
    this.activityModel.idIncident = this.formActivity.get('idIncident').value.idIncident;
    this.activityModel.idStatus = this.formActivity.get('idStatus').value.idStatus;
    this.activityModel.idSection = this.formActivity.get('idSection').value.idSection;
    this.activityService.insert(this.activityModel).subscribe(c => {
    }, e => {
    });
  }
}
