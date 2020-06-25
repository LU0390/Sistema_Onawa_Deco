import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfesoresSeminariosFormComponent } from './profesores-seminarios-form.component';

describe('ProfesoresSeminariosFormComponent', () => {
  let component: ProfesoresSeminariosFormComponent;
  let fixture: ComponentFixture<ProfesoresSeminariosFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfesoresSeminariosFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfesoresSeminariosFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
