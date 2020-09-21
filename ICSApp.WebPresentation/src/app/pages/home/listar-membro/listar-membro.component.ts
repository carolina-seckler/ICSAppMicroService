import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { MemberModel } from 'src/app/models/member';
import { FunctionService } from 'src/app/services/function.service';
import { IncidentService } from 'src/app/services/incident.service';
import { MemberService } from 'src/app/services/member.service';
import { SectionService } from 'src/app/services/section.service';

@Component({
  selector: 'app-listar-membro',
  templateUrl: './listar-membro.component.html',
  styleUrls: ['./listar-membro.component.scss']
})
export class ListarMembroComponent implements OnInit {

  members: MemberModel[];

  cols: any[];

  constructor(private memberService: MemberService,
              private incidentService: IncidentService,
              private sectionService: SectionService,
              private functionService: FunctionService) { }

  ngOnInit(): void {
    this.memberService.getAll().subscribe(result => {
      this.members = result;

      for (const item of this.members){
        this.incidentService.getById(item.idIncident).subscribe(x => {
          item.nameIncident = x.name;
        }, e => {
        });
        this.sectionService.getById(item.idSection).subscribe(x => {
          item.nameSection = x.name;
        }, e => {
        });
        this.functionService.getById(item.idFunction).subscribe(x => {
          item.nameFunction = x.name;
        }, e => {
        });
      }
    }, e => {
    });

    this.cols = [
      { field: 'name', header: 'Nome' },
      { field: 'nameIncident', header: 'Incidente' },
      { field: 'nameSection', header: 'Seção' },
      { field: 'nameFunction', header: 'Função' }
  ];
  }

  update(event){
    console.log(event);
  }

  remove(event){
    this.memberService.delete(event.idMember).subscribe(result => {
    }, e => {
      console.log(e);
    });
  }

}
