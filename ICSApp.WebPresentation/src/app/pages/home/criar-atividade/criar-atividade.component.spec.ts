import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CriarAtividadeComponent } from './criar-atividade.component';

describe('CriarAtividadeComponent', () => {
  let component: CriarAtividadeComponent;
  let fixture: ComponentFixture<CriarAtividadeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CriarAtividadeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CriarAtividadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
