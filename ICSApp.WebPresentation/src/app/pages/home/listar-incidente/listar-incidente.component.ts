import { Component, OnInit } from '@angular/core';
import { IncidentService } from 'src/app/services/incident.service';
import { IncidentModel } from 'src/app/models/incident';

@Component({
  selector: 'app-listar-incidente',
  templateUrl: './listar-incidente.component.html',
  styleUrls: ['./listar-incidente.component.scss']
})

export class ListarIncidenteComponent implements OnInit {

    incidents: IncidentModel[];

    cols: any[];

    constructor(private incidentService: IncidentService) { }

    ngOnInit() {
        this.incidentService.getAll().subscribe(result => {
          this.incidents = result;
        }, e => {
        });

        this.cols = [
            { field: 'name', header: 'Nome' },
            { field: 'incidentDate', header: 'Data' }
        ];
    }

    update(event){
      console.log(event);
    }

    remove(event){
      this.incidentService.delete(event.idIncident).subscribe(result => {
      }, e => {
        console.log(e);
      });
    }

}
