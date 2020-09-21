import { FunctionService } from './../../../services/function.service';
import { Component, OnInit } from '@angular/core';
import { MemberModel } from 'src/app/models/member';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MemberService } from 'src/app/services/member.service';
import { IncidentService } from 'src/app/services/incident.service';
import { SectionService } from 'src/app/services/section.service';
import { MessageService, PrimeNGConfig } from 'primeng/api';

@Component({
  selector: 'app-criar-membro',
  templateUrl: './criar-membro.component.html',
  styleUrls: ['./criar-membro.component.scss'],
  providers: [MessageService]
})

export class CriarMembroComponent implements OnInit {

  memberModel = new MemberModel();
  formMember: FormGroup;
  optIncident = [];
  optFunction = [];
  optSection = [];


  constructor(private fb: FormBuilder,
              private memberService: MemberService,
              private incidentService: IncidentService,
              private functionService: FunctionService,
              private sectionService: SectionService,
              private messageService: MessageService,
              private primengConfig: PrimeNGConfig) { }

  ngOnInit(): void {

    this.primengConfig.ripple = true;

    this.incidentService.getAll().subscribe(result => {
      this.optIncident = result;
    }, e => {
    });

    this.functionService.getAll().subscribe(result => {
      this.optFunction = result;
    }, e => {
    });

    this.sectionService.getAll().subscribe(result => {
      this.optSection = result;
    }, e => {
    });

    this.formMember = this.fb.group({
      name: ['', Validators.required],
      idIncident: ['', Validators.required],
      idFunction: ['', Validators.required],
      idSection: ['', Validators.required]
    });
  }

  salvar(): void{
    if (!this.formMember) {
      return;
    }
    this.memberModel.name = this.formMember.get('name').value;
    this.memberModel.idIncident = this.formMember.get('idIncident').value.idIncident;
    this.memberModel.idFunction = this.formMember.get('idFunction').value.idFunction;
    this.memberModel.idSection = this.formMember.get('idSection').value.idSection;
    this.memberService.insert(this.memberModel).subscribe(c => {
      this.messageService.add(
        { severity: 'sucess',
          summary: 'Login',
          detail: 'Sucesso',
          life: 3000
        }
      );
    }, e => {
    });
  }

}
