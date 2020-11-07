import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { ActivityModel } from 'src/app/models/activity';
import { ActivityService } from 'src/app/services/activity.service';
import { IncidentService } from 'src/app/services/incident.service';
import { SectionService } from 'src/app/services/section.service';
import { StatusService } from 'src/app/services/status.service';

@Component({
  selector: 'app-listar-atividade',
  templateUrl: './listar-atividade.component.html',
  styleUrls: ['./listar-atividade.component.scss']
})
export class ListarAtividadeComponent implements OnInit {

  activities: ActivityModel[];

  cols: any[];

  constructor(private activityService: ActivityService,
              private incidentService: IncidentService,
              private sectionService: SectionService,
              private statusService: StatusService) { }

  ngOnInit(): void {
    this.activityService.getAll().subscribe(result => {
      this.activities = result;

      for (const item of this.activities){
        this.incidentService.getById(item.idIncident).subscribe(x => {
          item.nameIncident = x.name;
        }, e => {
        });
        this.sectionService.getById(item.idSection).subscribe(x => {
          item.nameSection = x.name;
        }, e => {
        });
        this.statusService.getById(item.idStatus).subscribe(x => {
          item.nameStatus = x.name;
        }, e => {
        });
      }
    }, e => {
    });

    this.cols = [
      { field: 'description', header: 'Descrição' },
      { field: 'nameIncident', header: 'Incidente' },
      { field: 'nameSection', header: 'Seção' },
      { field: 'nameStatus', header: 'Status' }
  ];
  }

  update(event){
    console.log(event);
  }

  remove(event){
    this.activityService.delete(event.idActivity).subscribe(result => {
    }, e => {
      console.log(e);
    });
  }

}
