import { Component, OnInit, ChangeDetectionStrategy, OnChanges, SimpleChanges } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { MessageService, PrimeNGConfig } from 'primeng/api';
import { UserService } from 'src/app/services/user.service';
import { ModalControleService } from 'src/app/shared/modal-controle.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  providers: [MessageService],
  changeDetection: ChangeDetectionStrategy.Default
})
export class HomeComponent implements OnInit {

  usuario: string;
  dateTime = new Date().toDateString();
  displayNovoIncidenteModal = false;
  displayNovoMembroModal = false;
  displayNovaAtividadeModal = false;
  displayListarIncidenteModal = false;
  displayListarMembroModal = false;
  displayListarAtividadeModal = false;
  isSalvar = false;

  constructor(private fb: FormBuilder,
              private userService: UserService,
              private modalControleService: ModalControleService,
              private router: Router,
              private messageService: MessageService,
              private primengConfig: PrimeNGConfig) {
    this.userService.getIncidentUser().subscribe(result => {
      this.usuario = result.name;
    }, e => {
      console.log(e.error);
    });
  }

  ngOnInit(): void {
    this.primengConfig.ripple = true;

    this.userService.getActivityUser().subscribe(result => {
    }, e => {
      console.log(e.error);
    });
  }

  criarMembro(): void {
    this.displayNovoMembroModal = true;
  }

  criarIncidente(): void {
    this.displayNovoIncidenteModal = true;
  }

  criarAtividade(): void {
    this.displayNovaAtividadeModal = true;
  }

  criarRecurso(): void {

  }

  listarMembros(): void {
    this.displayListarMembroModal = true;
  }

  listarIncidentes(): void {
    this.displayListarIncidenteModal = true;
  }

  listarAtividades(): void {
    this.displayListarAtividadeModal = true;
  }

  listarRecursos(): void {

  }

  montarSituacao(): void{

  }

  logout() {
    // this.bankService.Logout().subscribe(c => {
    //   this.router.navigateByUrl('/login');
    // }, e => {
    //   this.messageService.add(
    //     { severity: 'error',
    //       summary: 'Login',
    //       detail: e.error.Message,
    //       life: 3000
    //     }
    //   );
    // });
  }
}
