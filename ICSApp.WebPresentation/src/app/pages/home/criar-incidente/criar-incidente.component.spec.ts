import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CriarIncidenteComponent } from './criar-incidente.component';

describe('CriarIncidenteComponent', () => {
  let component: CriarIncidenteComponent;
  let fixture: ComponentFixture<CriarIncidenteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CriarIncidenteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CriarIncidenteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
