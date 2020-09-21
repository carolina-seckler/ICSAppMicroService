import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { CriarIncidenteComponent } from './criar-incidente/criar-incidente.component';
import { ToastModule } from 'primeng/toast';
import {CalendarModule} from 'primeng/calendar';
import { CriarMembroComponent } from './criar-membro/criar-membro.component';
import { CriarAtividadeComponent } from './criar-atividade/criar-atividade.component';
import { TableModule } from 'primeng/table';
import { ListarIncidenteComponent } from './listar-incidente/listar-incidente.component';

@NgModule({
  declarations: [
    HomeComponent,
    CriarIncidenteComponent,
    CriarMembroComponent,
    CriarAtividadeComponent,
    ListarIncidenteComponent
  ],
  imports: [
    CommonModule,
    ButtonModule,
    InputTextModule,
    DialogModule,
    FormsModule,
    ReactiveFormsModule,
    DropdownModule,
    ToastModule,
    CalendarModule,
    TableModule
  ],
  exports: [
    HomeComponent,
    CriarIncidenteComponent,
    CriarMembroComponent,
    CriarAtividadeComponent,
    ListarIncidenteComponent
  ]
})

export class HomeModule { }
