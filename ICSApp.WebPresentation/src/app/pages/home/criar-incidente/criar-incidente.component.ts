import { Component, OnInit } from '@angular/core';
import { IncidentModel } from 'src/app/models/incident';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { IncidentService } from 'src/app/services/incident.service';

@Component({
  selector: 'app-criar-incidente',
  templateUrl: './criar-incidente.component.html',
  styleUrls: ['./criar-incidente.component.scss']
})
export class CriarIncidenteComponent implements OnInit {

  incidentModel = new IncidentModel();
  formIncident: FormGroup;

  constructor(private fb: FormBuilder,
              private incidentService: IncidentService) { }

  ngOnInit(): void {
    this.formIncident = this.fb.group({
      name: ['', Validators.required],
      incidentDate: ['', Validators.required]
    });
  }

  salvar(): void{
    if (!this.formIncident) {
      return;
    }
    this.incidentModel.name = this.formIncident.get('name').value;
    this.incidentModel.incidentDate = this.formIncident.get('incidentDate').value;
    this.incidentService.insert(this.incidentModel).subscribe(c => {
    }, e => {
    });
  }

}
