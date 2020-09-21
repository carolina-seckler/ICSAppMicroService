import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CriarMembroComponent } from './criar-membro.component';

describe('CriarMembroComponent', () => {
  let component: CriarMembroComponent;
  let fixture: ComponentFixture<CriarMembroComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CriarMembroComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CriarMembroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
