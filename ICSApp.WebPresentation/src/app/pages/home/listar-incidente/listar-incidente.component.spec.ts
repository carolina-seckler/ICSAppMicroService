import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarIncidenteComponent } from './listar-incidente.component';

describe('ListarIncidenteComponent', () => {
  let component: ListarIncidenteComponent;
  let fixture: ComponentFixture<ListarIncidenteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListarIncidenteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListarIncidenteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
