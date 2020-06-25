import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfesoresSeminariosComponent } from './profesores-seminarios.component';

describe('ProfesoresSeminariosComponent', () => {
  let component: ProfesoresSeminariosComponent;
  let fixture: ComponentFixture<ProfesoresSeminariosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfesoresSeminariosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfesoresSeminariosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
